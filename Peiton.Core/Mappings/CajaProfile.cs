using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CajaProfile : Profile
{
    public CajaProfile()
    {
        CreateMap<Ent.Caja, VM.Caja.CajaViewModel>()
            .ForMember(vm => vm.Autorizador, opt => opt.MapFrom(obj => obj.Usuario.NombreCompleto));

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
    }
}