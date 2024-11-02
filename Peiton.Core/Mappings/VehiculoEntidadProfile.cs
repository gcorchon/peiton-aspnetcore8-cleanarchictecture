using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VehiculoEntidadProfile : Profile
{
    public VehiculoEntidadProfile()
    {
        CreateMap<Ent.VehiculoEntidad, VM.VehiculosEntidad.VehiculoEntidadViewModel>()
            .ForMember(vm => vm.Descripcion, opt => opt.MapFrom(u => string.Format("{0} - {1} {2} - {3} - {4}", u.Matricula, u.Marca, u.Modelo, u.Color, u.Combustible)));

    }
}