using AutoMapper;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ControlRendicionProfile : Profile
{
    public ControlRendicionProfile()
    {
        CreateMap<Ent.ControlRendicion, VM.ControlRendiciones.ControlRendicionListItem>()
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(ent => ent.Nombramiento != null ? ent.Nombramiento.Descripcion : null))
            .ForMember(vm => vm.FechaInicio, opt => opt.MapFrom(ent => ObtenerFechaInicio(ent)))
            .ForMember(vm => vm.FechaFin, opt => opt.MapFrom(ent => ObtenerFechaFin(ent)))
            .ForMember(vm => vm.FechaResolucion, opt => opt.MapFrom(ent => ObtenerFechaResolucion(ent)))
            .ForMember(vm => vm.EstadoAprobacionRendicion, opt => opt.MapFrom(ent => ent.EstadoAprobacionRendicion != null ? ent.EstadoAprobacionRendicion.Descripcion : null))
            .ForMember(vm => vm.EstadoRetribucion, opt => opt.MapFrom(ent => ent.EstadoRetribucion != null ? ent.EstadoRetribucion.Descripcion : null));

        CreateMap<Ent.ControlRendicion, VM.ControlRendiciones.ControlRendicionViewModel>();

        CreateMap<VM.ControlRendiciones.CrearControlRendicionRequest, Ent.ControlRendicion>();
        CreateMap<VM.ControlRendiciones.ActualizarControlRendicionRequest, Ent.ControlRendicion>();
    }


    private static DateTime? ObtenerFechaInicio(ControlRendicion rendicion)
    {
        if (rendicion.TipoRendicionId == 1 && rendicion.FechaInicioIncidencia.HasValue)
        {
            return rendicion.FechaInicioIncidencia;
        }

        if (rendicion.TipoRendicionId == 2 && rendicion.FechaInicioRendicion.HasValue)
        {
            return rendicion.FechaInicioRendicion;
        }

        return null;
    }

    private static DateTime? ObtenerFechaFin(ControlRendicion rendicion)
    {
        if (rendicion.TipoRendicionId == 1 && rendicion.FechaFinIncidencia.HasValue)
        {
            return rendicion.FechaInicioIncidencia;
        }

        if (rendicion.TipoRendicionId == 2 && rendicion.FechaFinRendicion.HasValue)
        {
            return rendicion.FechaInicioRendicion;
        }

        return null;
    }


    private static DateTime? ObtenerFechaResolucion(ControlRendicion rendicion)
    {
        return rendicion.EstadoRetribucionId switch
        {
            1 => rendicion.FechaRetribucionConcedida,
            2 => rendicion.FechaRetribucionCondicionada,
            3 => rendicion.FechaRetribucionDenegada,
            _ => null
        };
    }
}