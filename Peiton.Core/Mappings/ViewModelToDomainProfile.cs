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
               
        }
    }
}