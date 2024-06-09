using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peiton.Core.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace Peiton.Server.Authorization
{

    public class AuthorizeTuteladoViewAttribute : ServiceFilterAttribute
    {
        public AuthorizeTuteladoViewAttribute()
            : base(typeof(AuthorizeTuteladoViewFilter))
        {

        }
    }

    public class AuthorizeTuteladoViewFilter :  IAuthorizationFilter
    {
        private readonly IUsuarioRepository usuarioRepository;

        public AuthorizeTuteladoViewFilter(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);

            if (userIdClaim == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            int userId = Convert.ToInt32(userIdClaim.Value);
            int tuteladoId;

            if(!int.TryParse(context.RouteData.Values["id"]?.ToString(), out tuteladoId))
            {
                context.Result = new BadRequestResult();
                return;
            }

            if (!usuarioRepository.CanViewTutelado(userId, tuteladoId))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
