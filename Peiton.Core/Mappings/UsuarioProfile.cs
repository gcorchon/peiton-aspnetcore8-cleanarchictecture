using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Ent.Usuario, VM.Common.ListItem>()
            .ForMember(v => v.Text, opt => opt.MapFrom(u => u.NombreCompleto))
            .ForMember(v => v.Value, opt => opt.MapFrom(u => u.Id));

        CreateMap<Ent.Usuario, VM.Usuarios.UsuarioConGrupos>();
    }
}