using AutoMapper;
using Newtonsoft.Json;
using Peiton.Authorization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Ent.Usuario, VM.Common.ListItem>()
            .ForMember(v => v.Text, opt => opt.MapFrom(u => u.NombreCompleto))
            .ForMember(v => v.Value, opt => opt.MapFrom(u => u.Id));

        CreateMap<Ent.Usuario, VM.Usuarios.UsuarioConGrupos>();

        CreateMap<Ent.Usuario, VM.Usuarios.UsuarioViewModel>()
            .ForMember(v => v.Permisos, opt => opt.MapFrom(u => u.Permisos.Select(p => p.Id)))
            .ForMember(v => v.PermisosGrupo, opt => opt.MapFrom(u => u.Grupos.SelectMany(g => g.Permisos.Select(p => p.Id)).Distinct()))
            .ForMember(v => v.Info, opt => opt.MapFrom(u => u.Info != null ? JsonConvert.DeserializeObject<VM.Usuarios.Info>(u.Info) : null));

        CreateMap<Ent.Usuario, VM.Usuarios.UsuarioBloqueado>();

        CreateMap<Ent.Usuario, VM.Mensajes.Remitente>();

        CreateMap<Ent.Usuario, VM.Usuarios.UsuarioPermisoEmail>()
            .ForMember(v => v.RecibirMensajes, opt => opt.MapFrom(u => u.Permisos.Any(p => p.Id == PeitonPermission.ComunicacionesRecibirMensajesPorEmail) ||
                                                                       u.Grupos.SelectMany(g => g.Permisos).Any(p => p.Id == PeitonPermission.ComunicacionesRecibirMensajesPorEmail)))
            .ForMember(v => v.RecibirMensajesHeredado, opt => opt.MapFrom(u => u.Grupos.SelectMany(g => g.Permisos).Any(p => p.Id == PeitonPermission.ComunicacionesRecibirMensajesPorEmail)));

    }
}