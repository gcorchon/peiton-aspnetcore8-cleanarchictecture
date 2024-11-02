using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VwCajaAMTAProfile : Profile
{
    public VwCajaAMTAProfile()
    {
        CreateMap<Ent.VwCajaAMTA, VM.Caja.CajaAMTAListItem>()
            .ForMember(vm => vm.PersonaReceptora, m => m.MapFrom(o => o.Persona ?? o.Tutelado!.NombreCompleto));
    }
}