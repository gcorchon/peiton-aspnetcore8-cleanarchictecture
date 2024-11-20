using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AgendaProfile : Profile
{
    public AgendaProfile()
    {
        CreateMap<Ent.Agenda, VM.Seguimientos.SeguimientoListItem>()
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(ent => ent.Usuario.NombreCompleto))
            .ForMember(vm => vm.CategoriaAgenda, opt => opt.MapFrom(ent => ent.CategoriaAgenda.Descripcion))
            .ForMember(vm => vm.AgendaAreaActuacion, opt => opt.MapFrom(ent => ent.AgendaAreaActuacion != null ? ent.AgendaAreaActuacion.Descripcion : null));

        CreateMap<Ent.Agenda, VM.Seguimientos.SeguimientoViewModel>().ReverseMap();

        CreateMap<VM.Seguimientos.CrearSeguimientoRequest, Ent.Agenda>();
        CreateMap<VM.Seguimientos.ActualizarSeguimientoRequest, Ent.Agenda>();
        CreateMap<VM.Seguimientos.CrearSeguimientoMasivoRequest, Ent.Agenda>();
    }
}