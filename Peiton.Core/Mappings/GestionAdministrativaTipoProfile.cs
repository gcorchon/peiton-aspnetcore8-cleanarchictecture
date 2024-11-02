using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class GestionAdministrativaTipoProfile : Profile
{
    public GestionAdministrativaTipoProfile()
    {
        CreateMap<Ent.GestionAdministrativaTipo, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Descripcion));
    }
}