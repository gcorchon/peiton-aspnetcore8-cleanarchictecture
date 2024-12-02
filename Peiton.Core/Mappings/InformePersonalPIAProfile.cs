using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InformePersonalPIAProfile : Profile
{
    public InformePersonalPIAProfile()
    {
        CreateMap<Ent.InformePersonalPIA, VM.InformesPersonalesPIA.InformePersonalPIAListItem>()
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(o => o.Usuario.NombreCompleto));
    }
}