using System.Xml.Linq;
using AutoMapper;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TareaProfile : Profile
{
    public TareaProfile()
    {
        CreateMap<Ent.Tarea, VM.Tareas.TareaListItem>()
            .ForMember(vm => vm.TareaDepartamento, opt => opt.MapFrom(ent => ent.TareaDepartamento != null ? ent.TareaDepartamento.Descripcion : null))
            .ForMember(vm => vm.TareaCategoria, opt => opt.MapFrom(ent => ent.TareaCategoria != null ? ent.TareaCategoria.Descripcion : null))
            .ForMember(vm => vm.TareaSubcategoria, opt => opt.MapFrom(ent => ent.TareaSubcategoria != null ? ent.TareaSubcategoria.Descripcion : null))
            .ForMember(vm => vm.TareaTipo, opt => opt.MapFrom(ent => ent.TareaTipo != null ? ent.TareaTipo.Descripcion : null))
            .ForMember(vm => vm.UsuarioGestor, opt => opt.MapFrom(ent => ent.UsuarioGestor != null ? ent.UsuarioGestor.NombreCompleto : null));

        CreateMap<Ent.Tarea, VM.Tareas.TareaViewModel>()
            .ForMember(vm => vm.Archivos, opt => opt.MapFrom(ent => ent.Archivos.Deserialize<string[]>() ?? new string[0]))
            .ForMember(vm => vm.AlertasEnviadas, opt => opt.MapFrom(ent => Deserialize(ent.AlertasEnviadas)));

        CreateMap<VM.Tareas.CrearTareaRequest, Ent.Tarea>()
            .ForMember(ent => ent.AlertasEnviadas, opt => opt.Ignore())
            .ForMember(ent => ent.Archivos, opt => opt.MapFrom(vm => vm.Archivos.ToXDocument()));

        CreateMap<VM.Tareas.ActualizarTareaRequest, Ent.Tarea>()
            .ForMember(ent => ent.AlertasEnviadas, opt => opt.Ignore())
            .ForMember(ent => ent.Archivos, opt => opt.MapFrom(vm => vm.Archivos.ToXDocument()));

    }

    private VM.Tareas.Alerta[] Deserialize(string? xml)
    {
        if (xml == null) return [];
        return XDocument.Parse(xml).Root!.Elements("alerta")
            .Select(node => new VM.Tareas.Alerta()
            {
                Fecha = DateTime.ParseExact(node.Attribute("fecha")!.Value, "yyyy-MM-dd HH:mm:ss", null),
                Usuarios = node.Value
            }).ToArray();
    }
}