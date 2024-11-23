using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VwCategoriaProfile : Profile
{
    public VwCategoriaProfile()
    {
        CreateMap<Ent.VwCategoria, VM.Common.ListItem>()
                    .ForMember(vm => vm.Id, opt => opt.MapFrom(o => o.Id))
                    .ForMember(vm => vm.Text, opt => opt.MapFrom(o => o.BreadCrumb));
    }
}