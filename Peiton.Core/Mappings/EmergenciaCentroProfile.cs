using AutoMapper;
using Peiton.Contracts.Emergencias;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class EmergenciaCentroProfile : Profile
{
    public EmergenciaCentroProfile()
    {
        CreateMap<Ent.EmergenciaCentro,VM.EmergenciasCentros.EmergenciaCentroListItem>()
            .ForMember(vm => vm.MotivoEmergenciaCentro, opt => opt.MapFrom(e => e.MotivoEmergenciaCentro.Descripcion))
            .ForMember(vm => vm.TieneListaComprobacion, opt => opt.MapFrom(e => e.CheckList != null && e.CheckList.Deserialize<CheckListItem[]>()!.Any()));

    }
    
    public EmergenciaCentroProfile(IIdentityService identityService){
        CreateMap<VM.EmergenciasCentros.CrearEmergenciaCentroRequest, Ent.EmergenciaCentro>()
            .ForMember(ent => ent.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()));
    }
}