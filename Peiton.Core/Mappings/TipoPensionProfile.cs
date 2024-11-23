using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TipoPensionProfile : Profile
{
    public TipoPensionProfile()
    {
        CreateMap<Ent.TipoPension, VM.Common.ListItem>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(e => e.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(e => e.Descripcion));
    }
}