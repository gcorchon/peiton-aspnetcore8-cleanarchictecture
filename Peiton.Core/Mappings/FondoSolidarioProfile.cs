using AutoMapper;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class FondoSolidarioProfile : Profile
{
    public FondoSolidarioProfile()
    {
        CreateMap<Ent.FondoSolidario, VM.FondosSolidarios.FondoSolidarioListItem>()
            .ForMember(vm => vm.FondoSolidarioDestino, opt => opt.MapFrom(f => f.FondoSolidarioDestino.Descripcion))
            .ForMember(vm => vm.Solicitante, opt => opt.MapFrom(f => f.Solicitante.NombreCompleto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(f => Estado(f)))
            .ForMember(vm => vm.Caducado, opt => opt.MapFrom(f => Caducado(f)))
            .ForMember(vm => vm.Renovable, opt => opt.MapFrom(f => f.Pagado && !Caducado(f)));

        CreateMap<Ent.FondoSolidario, VM.FondosSolidarios.FondoSolidarioViewModel>();

        CreateMap<Ent.FondoSolidario, VM.FondosSolidarios.FondoSolidarioExtendidoListItem>()
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(f => f.Tutelado.NombreCompleto))
            .ForMember(vm => vm.FondoSolidarioTipoFondo, opt => opt.MapFrom(f => f.FondoSolidarioTipoFondo.Descripcion))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(f => Estado(f)))
            .ForMember(vm => vm.Caducado, opt => opt.MapFrom(f => Caducado(f)));

        CreateMap<Ent.FondoSolidario, VM.FondosSolidarios.FondoSolidarioExtendidoViewModel>()
            .ForMember(vm => vm.FondoSolidarioTipoFondo, opt => opt.MapFrom(f => f.FondoSolidarioTipoFondo.Descripcion))
            .ForMember(vm => vm.FondoSolidarioDestino, opt => opt.MapFrom(f => f.FondoSolidarioDestino.Descripcion))
            .ForMember(vm => vm.FondoSolidarioFormaPago, opt => opt.MapFrom(f => f.FondoSolidarioFormaPago != null ? f.FondoSolidarioFormaPago.Descripcion : null))
            .ForMember(vm => vm.Solicitante, opt => opt.MapFrom(f => f.Solicitante.NombreCompleto))
            .ForMember(vm => vm.Revisor, opt => opt.MapFrom(f => f.Revisor != null ? f.Revisor.NombreCompleto : null))
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(f => f.Autorizador != null ? f.Autorizador.NombreCompleto : null))
            .ForMember(vm => vm.Pagador, opt => opt.MapFrom(f => f.Pagador != null ? f.Pagador.NombreCompleto : null))
            .ForMember(vm => vm.Verificador, opt => opt.MapFrom(f => f.Verificador != null ? f.Verificador.NombreCompleto : null));

        CreateMap<VM.FondosSolidarios.CrearFondoSolidarioRequest, Ent.FondoSolidario>();
    }

    private static string Estado(FondoSolidario fondo)
    {
        if (fondo.Rechazado) return "Rechazado";
        else if (fondo.Pagado) return "Pagado";
        else if (fondo.Autorizado) return "Autorizado";
        else if (fondo.Revisado) return "Revisado";
        else if (fondo.Verificado) return "Verificado";
        return "Pendiente";
    }

    private static bool Caducado(FondoSolidario fondo)
    {
        return fondo.FechaBaja.HasValue && fondo.FechaBaja.Value < DateTime.Now;
    }

}