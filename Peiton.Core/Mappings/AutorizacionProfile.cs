using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AutorizacionProfile : Profile
{
    public AutorizacionProfile()
    {
        CreateMap<Ent.Autorizacion,VM.Autorizaciones.AutorizacionListItem>();        
    }

    public AutorizacionProfile(IIdentityService identityService)
    {        
        CreateMap<VM.Autorizaciones.ActualizarAutorizacionRequest, Ent.Autorizacion>()
            .ForMember(e => e.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()))
            .ForMember(e => e.Aprobada, opt => opt.MapFrom(vm => false))
            .ForMember(e => e.FechaSolicitud, opt => opt.MapFrom(vm => DateTime.Now));

        CreateMap<VM.Autorizaciones.CrearAutorizacionRequest, Ent.Autorizacion>()
            .ForMember(e => e.UsuarioId, opt => opt.MapFrom(vm => identityService.GetUserId()))
            .ForMember(e => e.Aprobada, opt => opt.MapFrom(vm => false))
            .ForMember(e => e.FechaSolicitud, opt => opt.MapFrom(vm => DateTime.Now));
    }
}