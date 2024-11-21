using AutoMapper;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VehiculoEntidadProfile : Profile
{
    public VehiculoEntidadProfile()
    {
        CreateMap<Ent.VehiculoEntidad, VM.VehiculosEntidad.VehiculoEntidadViewModel>()
            .ForMember(vm => vm.Descripcion, opt => opt.MapFrom(u => ObtenerLiteral(u) ));

    }

    private string ObtenerLiteral(VehiculoEntidad u)
    {
        return string.Format("{0} - {1} {2} - {3} - {4}", u.Matricula, u.Marca, u.Modelo, u.Color, u.Combustible);
    }
}