using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Peiton.Configuration;
using Peiton.Contracts.Security;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Security;

[Injectable]
public class GetTokenHandler
{
    private readonly JwtConfig jwtConfig;
    private readonly ICryptographyService cryptographyService;
    private readonly IUsuarioRepository usuarioRepository;
    private readonly ILogAccesoRepository logAccesoRepository;
    private readonly IHttpContextAccessor context;
    private readonly IUnitOfWork unitOfWork;

    public GetTokenHandler(IUsuarioRepository usuarioRepository, ICryptographyService cryptographyService,
                           IUnitOfWork unitOfWork, ILogAccesoRepository logAccesoRepository, IHttpContextAccessor context,
                           IOptions<JwtConfig> jwtConfig)
    {
        this.usuarioRepository = usuarioRepository;
        this.cryptographyService = cryptographyService;
        this.unitOfWork = unitOfWork;
        this.logAccesoRepository = logAccesoRepository;
        this.context = context;
        this.jwtConfig = jwtConfig.Value;
    }

    public async Task<TokenViewModel> HandleAsync(TokenRequest request)
    {
        var user = await this.usuarioRepository.GetAsync(u => u.Username == request.UserName);
        if (user == null || user.Borrado) throw new UnauthorizedAccessException("Usuario y/o contraseña incorrectos");
        if (user.Bloqueado) throw new UnauthorizedAccessException("El usuario está bloqueado");

        var hashedPassword = cryptographyService.GetMd5Hash(request.Password);

        if (user.Pwd != hashedPassword)
        {
            user.Reintentos += 1;
            user.Bloqueado = user.Reintentos >= 3;
            await unitOfWork.SaveChangesAsync();
            throw new UnauthorizedAccessException("Usuario y/o contraseña incorrectos");
        }

        if (context.HttpContext is null) throw new Exception("HttpContext required");

        var remoteIPAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";

        user.Reintentos = 0;
        user.UserAgent = context.HttpContext.Request.Headers.UserAgent;

        await logAccesoRepository.AddAsync(new LogAcceso() { Fecha = DateTime.Now, Usuario = user.Username, IP = remoteIPAddress });
        await unitOfWork.SaveChangesAsync();

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtConfig.Secret!);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Nombre),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Apellidos),
            new Claim("ipaddr", remoteIPAddress),
            new Claim(ClaimTypes.Role, "ROLE_USER")
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMonths(1),
            Issuer = jwtConfig.Issuer,
            Audience = jwtConfig.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return new TokenViewModel { Token = jwtToken };
    }
}