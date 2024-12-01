using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CajaProfile : Profile
{
    public CajaProfile()
    {
        CreateMap<Ent.Caja, VM.Caja.CajaViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto))
            .ForMember(vm => vm.Centro, opt => opt.MapFrom(obj => obj.Centro != null ? obj.Centro.Nombre : null));

        CreateMap<Ent.Caja, VM.Caja.CajaListItem>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(obj => obj.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.TipoPago != null ? obj.TipoPago.Descripcion : null))
            .ForMember(vm => vm.TuteladoMuerto, opt => opt.MapFrom(obj => obj.Tutelado.Muerto))
            .ForMember(vm => vm.Estado, opt => opt.MapFrom(obj => obj.Pendiente ? "Pendiente" : "Pagado"));

        CreateMap<Ent.Caja, VM.Caja.HistoricoMovimientoListItem>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.TipoPago != null ? obj.TipoPago.Descripcion : null))
            .ForMember(vm => vm.Metodo, opt => opt.MapFrom(obj => obj.MetodoPago != null ? obj.MetodoPago.Descripcion : null));

        CreateMap<Ent.Caja, Ent.CajaIncidencia>()
            .ForMember(vm => vm.Id, opt => opt.Ignore())
            .ForMember(vm => vm.CajaId, opt => opt.MapFrom(c => c.Id));

        CreateMap<Ent.Caja, VM.Caja.CajaPendienteTuteladoListItem>()
            .ForMember(vm => vm.TipoPago, m => m.MapFrom(o => o.TipoPago != null ? o.TipoPago.Descripcion : null))
            .ForMember(vm => vm.MetodoPago, m => m.MapFrom(o => o.MetodoPago != null ? o.MetodoPago.Descripcion : null));

        CreateMap<Ent.Caja, VM.Caja.CajaPendienteTuteladoViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto));
    }

    public CajaProfile(IIdentityService identityService)
    {
        CreateMap<VM.Caja.ActualizarMovimientoCajaTuteladoRequest, Ent.Caja>()
            .ForMember(c => c.PeriodicidadId, m => m.MapFrom(v => v.TipoPagoId == 1 ? null : v.TipoPagoId))
            .ForMember(c => c.Importe, m => m.MapFrom(v => -Math.Abs(v.Importe)))
            .ForMember(c => c.UsuarioId, m => m.MapFrom(v => identityService.GetUserId()));

        CreateMap<VM.Caja.CrearMovimientoCajaTuteladoRequest, Ent.Caja>()
            .ForMember(c => c.PeriodicidadId, m => m.MapFrom(v => v.Tipo == 1 && v.TipoPagoId == 1 ? null : v.TipoPagoId))
            .ForMember(c => c.Importe, m => m.MapFrom(v => v.Tipo == 1 ? -Math.Abs(v.Importe) : Math.Abs(v.Importe)))
            .ForMember(c => c.FechaPago, m => m.MapFrom(v => v.Tipo == 1 ? (DateTime?)null : v.FechaAutorizacion))
            .ForMember(c => c.Pendiente, m => m.MapFrom(v => v.Tipo == 1))
            .ForMember(c => c.UsuarioId, m => m.MapFrom(v => identityService.GetUserId()));


        CreateMap<VM.Caja.ActualizarMovimientoCajaRequest, Ent.Caja>()
            .ForMember(c => c.Pendiente, m => m.MapFrom(v => false))
            .ForMember(c => c.FechaPago, m => m.MapFrom(v => DateTime.Now))
            .ForMember(c => c.PagadorId, m => m.MapFrom(v => identityService.GetUserId()));


    }
}