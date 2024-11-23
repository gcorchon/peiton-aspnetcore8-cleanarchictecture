using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class JuzgadoProfile : Profile
{
    public JuzgadoProfile()
    {
        CreateMap<Ent.Juzgado, VM.Common.ListItem>()
            .ForMember(vm => vm.Id, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Descripcion));
    }
}