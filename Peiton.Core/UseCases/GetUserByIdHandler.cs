using AutoMapper;
using Peiton.Contracts.Usuario;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core;

[Injectable]
public class GetUserByIdHandler
{
    private readonly IUsuarioRepository usuarioRepository;
    private readonly IMapper mapper;
    public GetUserByIdHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        this.usuarioRepository = usuarioRepository;
        this.mapper = mapper;
    }

    public async Task<UsuarioViewModel?> HandleAsync(int usuarioId)
    {
        var usuario = await usuarioRepository.GetByIdAsync(usuarioId);
        return mapper.Map<UsuarioViewModel>(usuario);
    }
}
