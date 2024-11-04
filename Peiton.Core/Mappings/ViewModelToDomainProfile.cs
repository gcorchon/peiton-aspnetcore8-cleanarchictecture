using AutoMapper;
using Newtonsoft.Json;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ViewModelToDomainProfile : Profile
{

    public ViewModelToDomainProfile()
    {

        CreateMap<VM.Capitulo.CreateCapituloRequest, Ent.Capitulo>();
        CreateMap<VM.Partida.CreatePartidaRequest, Ent.Partida>();
        CreateMap<VM.Facturas.GuardarFacturaRequest, Ent.Factura>();
        CreateMap<VM.AvisosTributarios.ActualizarAvisoTributarioRequest, Ent.AvisoTributario>();
        CreateMap<VM.AvisosTributarios.GuardarAvisoTributarioRequest, Ent.AvisoTributario>();
        CreateMap<VM.Inmuebles.GuardarInmuebleAvisoRequest, Ent.InmuebleAviso>();
        CreateMap<VM.Inmuebles.ActualizarInmuebleAutorizacionRequest, Ent.InmuebleAutorizacion>();
        CreateMap<VM.Inmuebles.ActualizarInmuebleSolicitudAlquilerVentaRequest, Ent.InmuebleSolicitudAlquilerVenta>();
        CreateMap<VM.Inmuebles.ActualizarSucesionRequest, Ent.Sucesion>();
        CreateMap<VM.Inmuebles.CrearSucesionRequest, Ent.Sucesion>();
        CreateMap<VM.Inmuebles.ActualizarInmuebleTasacionRequest, Ent.InmuebleTasacion>();
        CreateMap<VM.Inmuebles.CrearInmuebleTasacionRequest, Ent.InmuebleTasacion>();
        CreateMap<VM.Categorias.ActualizarCategoriaRequest, Ent.Categoria>();
        CreateMap<VM.CNAEs.ActualizarCNAERequest, Ent.CNAE>();
        CreateMap<VM.Ausencias.GuardarAusenciaRequest, Ent.Ausencia>();
        CreateMap<VM.Quejas.GuardarQuejaRequest, Ent.Queja>()
            .ForMember(ent => ent.QuejasMotivos, o => o.Ignore());
        CreateMap<VM.Senalamientos.GuardarSenalamientoRequest, Ent.Senalamiento>();
        CreateMap<VM.Centros.CentroViewModel, Ent.Centro>();
        CreateMap<VM.Salas.SalaListItem, Sala>();
        CreateMap<VM.Sucursales.SucursalViewModel, Sucursal>();
        CreateMap<VM.Usuarios.GuardarUsuarioRequest, Usuario>()
            .ForMember(ent => ent.Pwd, opt => opt.Ignore())
            .ForMember(ent => ent.Grupos, opt => opt.Ignore())
            .ForMember(ent => ent.Permisos, opt => opt.Ignore())
            .ForMember(ent => ent.Info, opt => opt.MapFrom(v => JsonConvert.SerializeObject(v.Info)));
    }
}
