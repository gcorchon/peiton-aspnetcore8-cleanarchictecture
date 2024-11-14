using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TributoTuteladoProfile : Profile
{
    public TributoTuteladoProfile()
    {
        CreateMap<Ent.TributoTutelado, VM.Tributos.TributoViewModel>().ReverseMap();

        CreateMap<Ent.TributoTutelado, VM.Tributos.TributoListItem>()
            .ForMember(vm => vm.Tributo, opt => opt.MapFrom(t => t.Tributo.Descripcion));

        CreateMap<VM.Tributos.CrearTributoRequest, Ent.TributoTutelado>();
    }
}