using System.Xml.Linq;
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

        CreateMap<Ent.Agenda, VM.Seguimientos.SeguimientoViewModel>()
            .ForMember(vm => vm.AlertasEnviadas, opt => opt.MapFrom(e => Deserialize(e.AlertasEnviadas)));

        CreateMap<VM.Seguimientos.SeguimientoViewModel, Ent.Agenda>()
            .ForMember(ent => ent.AlertasEnviadas, opt => opt.Ignore());

        CreateMap<VM.Seguimientos.CrearSeguimientoRequest, Ent.Agenda>()
            .ForMember(ent => ent.AlertasEnviadas, opt => opt.Ignore());

        CreateMap<VM.Seguimientos.ActualizarSeguimientoRequest, Ent.Agenda>()
            .ForMember(ent => ent.AlertasEnviadas, opt => opt.Ignore());

        CreateMap<VM.Seguimientos.CrearSeguimientoMasivoRequest, Ent.Agenda>();
    }

    private VM.Seguimientos.Alerta[] Deserialize(string? xml)
    {
        if (xml == null) return [];
        return XDocument.Parse(xml).Root!.Elements("alerta")
            .Select(node => new VM.Seguimientos.Alerta()
            {
                Fecha = DateTime.ParseExact(node.Attribute("fecha")!.Value, "yyyy-MM-dd HH:mm:ss", null),
                Usuarios = node.Value
            }).ToArray();
    }
}