using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ConsultaAlmacenadaProfile : Profile
{
    public ConsultaAlmacenadaProfile()
    {
        CreateMap<Ent.ConsultaAlmacenada, VM.Consultas.ConsultaViewModel>()
           .ForMember(vm => vm.CategoriaId, opt => opt.MapFrom(c => c.CategoriaConsultaId))
           .ForMember(vm => vm.Usuarios, opt => opt.MapFrom(c => c.Grupos.Select(g => new VM.Usuarios.UsuarioTipo() { Tipo = 2, Id = g.Id, Nombre = g.Descripcion })
                                                                  .Concat(c.Usuarios.Select(u => new VM.Usuarios.UsuarioTipo() { Tipo = 1, Id = u.Id, Nombre = u.NombreCompleto }))

           ));

    }
}