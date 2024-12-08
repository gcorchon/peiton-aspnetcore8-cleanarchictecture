using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CitaProfile : Profile
{
    public CitaProfile()
    {
        CreateMap<Ent.Cita,VM.Citas.CitaListItem>();        
    }

    public CitaProfile(IIdentityService identityService){
        CreateMap<VM.Citas.ActualizarCitaRequest, Ent.Cita>()
            .ForMember(e => e.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()))
            .ForMember(e => e.FechaCreacion, opt => opt.MapFrom(vm => DateTime.Now));

        CreateMap<VM.Citas.CrearCitaRequest, Ent.Cita>()
            .ForMember(e => e.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()))
            .ForMember(e => e.FechaCreacion, opt => opt.MapFrom(vm => DateTime.Now));            
    }
}