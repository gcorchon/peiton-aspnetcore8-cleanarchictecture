using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class GestorAdministrativoProfile : Profile
{
    public GestorAdministrativoProfile()
    {
        CreateMap<Ent.GestorAdministrativo, VM.Common.ListItem>()
            .ForMember(vm => vm.Id, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Nombre + " " + o.Apellidos));
    }
}