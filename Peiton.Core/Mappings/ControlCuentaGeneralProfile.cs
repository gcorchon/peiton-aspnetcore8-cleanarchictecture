using AutoMapper;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ControlCuentaGeneralProfile : Profile
{
    public ControlCuentaGeneralProfile()
    {
        CreateMap<Ent.ControlCuentaGeneral, VM.ControlCuentasGenerales.ControlCuentaGeneralListItem>()
            .ForMember(vm => vm.TipoCGJ, opt => opt.MapFrom(ent => ent.TipoCGJ != null ? ent.TipoCGJ.Descripcion : null))
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(ent => ObtenerNombramiento(ent)))
            .ForMember(vm => vm.EstadoAprobacionCGJ, opt => opt.MapFrom(ent => ent.EstadoAprobacionCGJ != null ? ent.EstadoAprobacionCGJ.Descripcion : null));

        CreateMap<Ent.ControlCuentaGeneral, VM.ControlCuentasGenerales.ControlCuentaGeneralViewModel>();

        CreateMap<VM.ControlCuentasGenerales.CrearControlCuentaGeneralRequest, Ent.ControlCuentaGeneral>();

        CreateMap<VM.ControlCuentasGenerales.ActualizarControlCuentaGeneralRequest, Ent.ControlCuentaGeneral>();
    }

    private static string? ObtenerNombramiento(ControlCuentaGeneral cuentaGeneral)
    {
        return cuentaGeneral.TipoCGJId switch
        {
            1 => cuentaGeneral.NombramientoArchivado?.Descripcion,
            2 => cuentaGeneral.NombramientoPresentada?.Descripcion,
            _ => "-"
        };
    }
}