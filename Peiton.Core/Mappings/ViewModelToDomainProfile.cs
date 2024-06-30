using AutoMapper;

using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings
{
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
        }
    }
}