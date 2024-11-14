using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TipoVehiculoProfile : Profile
{
    public TipoVehiculoProfile()
    {
        CreateMap<Ent.TipoVehiculo, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(c => c.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(c => c.Descripcion));
    }
}