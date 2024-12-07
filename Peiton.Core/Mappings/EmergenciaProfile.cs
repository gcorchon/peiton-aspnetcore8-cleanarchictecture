using AutoMapper;
using Peiton.Contracts.Emergencias;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class EmergenciaProfile : Profile
{
    public EmergenciaProfile()
    {
        CreateMap<Ent.Emergencia,VM.Emergencias.EmergenciaListItem>()
            .ForMember(vm => vm.MotivoEmergencia, opt => opt.MapFrom(e => e.MotivoEmergencia.Descripcion))
            .ForMember(vm => vm.EmergenciaLlamada, opt => opt.MapFrom(e => e.EmergenciaLlamada != null ? e.EmergenciaLlamada.Descripcion : null))
            .ForMember(vm => vm.TieneListaComprobacion, opt => opt.MapFrom(e => e.CheckList != null && e.CheckList.Deserialize<CheckListItem[]>()!.Any()));
    }

    public EmergenciaProfile(IIdentityService identityService){
        CreateMap<VM.Emergencias.CrearEmergenciaRequest, Ent.Emergencia>()
            .ForMember(ent => ent.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()));
    }
}