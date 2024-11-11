using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuteladoProfile : Profile
{

    public TuteladoProfile()
    {
        CreateMap<Ent.Tutelado, VM.Tutelados.TuteladoViewModel>();
        CreateMap<Ent.Tutelado, VM.Tutelados.TuteladoListItem>()
            .ForMember(vm => vm.NombreCompleto, opt => opt.MapFrom(t => t.Apellidos + ", " + t.Nombre))
            .ForMember(vm => vm.Cargo, opt => opt.MapFrom(t => t.DatosJuridicos != null && t.DatosJuridicos.Nombramiento != null ? t.DatosJuridicos.Nombramiento.Descripcion : null));

        CreateMap<Ent.Tutelado, VM.Caja.TuteladoReintegro>()
            .ForMember(vm => vm.Cuentas, opt => opt.MapFrom(t => t.Credenciales.SelectMany(c => c.Accounts)));

        CreateMap<Ent.Tutelado, VM.Inmuebles.TuteladoAvisoInmueble>()
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(c => c.DatosJuridicos != null && c.DatosJuridicos.Nombramiento != null ? c.DatosJuridicos.Nombramiento.Descripcion : null))
            .ForMember(vm => vm.SegurosHogar, opt => opt.MapFrom(c => c.SegurosContratados.Where(s => s.TipoSeguroId == 2)));

        CreateMap<Ent.Tutelado, VM.Inmuebles.TuteladoSolicitudAlquilerVenta>();

        CreateMap<Ent.Tutelado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.NombreCompleto));
    }

}
