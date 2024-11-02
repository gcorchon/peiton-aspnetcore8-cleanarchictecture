using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CajaAMTAProfile : Profile
{
    public CajaAMTAProfile()
    {
        CreateMap<Ent.CajaAMTA, VM.MovimientosPendientesCaja.MovimientoPendienteCajaListItem>()
            .ForMember(vm => vm.Persona, opt => opt.MapFrom(obj => !string.IsNullOrWhiteSpace(obj.Persona) ? obj.Persona : (obj.Tutelado != null ? obj.Tutelado.NombreCompleto : "")));

        CreateMap<Ent.CajaAMTA, VM.MovimientosPendientesCaja.MovimientoPendienteCajaViewModel>();
    }
}