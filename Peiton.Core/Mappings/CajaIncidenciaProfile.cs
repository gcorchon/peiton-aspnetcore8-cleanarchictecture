using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CajaIncidenciaProfile : Profile
{
    public CajaIncidenciaProfile()
    {
        CreateMap<Ent.CajaIncidencia, VM.Caja.IncidenciaListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(obj => obj.Tutelado.NombreCompleto))
            .ForMember(vm => vm.RazonIncidencia, opt => opt.MapFrom(obj => obj.RazonIncidenciaCaja.Descripcion));

        CreateMap<Ent.CajaIncidencia, VM.Caja.IncidenciaViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto));
    }
}