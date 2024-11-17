using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class EntidadFinancieraProfile : Profile
{
    public EntidadFinancieraProfile()
    {
        CreateMap<Ent.EntidadFinanciera, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(e => e.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(e => e.Descripcion));
    }
}