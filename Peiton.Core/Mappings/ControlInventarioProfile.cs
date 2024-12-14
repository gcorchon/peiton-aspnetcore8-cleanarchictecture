using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ControlInventarioProfile : Profile
{
    public ControlInventarioProfile()
    {
        CreateMap<Ent.ControlInventario, VM.ControlInventarios.ControlInventarioListItem>()
            .ForMember(vm => vm.EstadoInventario, opt => opt.MapFrom(ent => ent.EstadoInventario != null ? ent.EstadoInventario.Descripcion : null))
            .ForMember(vm => vm.EstadoAprobacionInventario, opt => opt.MapFrom(ent => ent.EstadoAprobacionInventario != null ? ent.EstadoAprobacionInventario.Descripcion : null))
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(ent => ent.Nombramiento != null ? ent.Nombramiento.Descripcion : null));

        CreateMap<Ent.ControlInventario, VM.ControlInventarios.ControlInventarioViewModel>();
    }

    public ControlInventarioProfile(IIdentityService identityService)
    {
        CreateMap<VM.ControlInventarios.CrearControlInventarioRequest, Ent.ControlInventario>()
            .ForMember(vm => vm.ProfesionalId, opt => opt.MapFrom(ent => identityService.GetUserId()));

        CreateMap<VM.ControlInventarios.ActualizarControlInventarioRequest, Ent.ControlInventario>()
            .ForMember(vm => vm.ProfesionalId, opt => opt.MapFrom(ent => identityService.GetUserId()));
    }
}