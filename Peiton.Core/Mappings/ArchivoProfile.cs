using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ArchivoProfile : Profile
{
    public ArchivoProfile()
    {
        CreateMap<Ent.Archivo, VM.Archivos.ArchivoViewModel>();
        CreateMap<VM.Archivos.CrearArchivoRequest, Ent.Archivo>()
            .ForMember(a => a.Fecha, opt => opt.MapFrom(vm => DateTime.Now))
            .ForMember(a => a.FileName, opt => opt.Ignore())
            .ForMember(a => a.ContentType, opt => opt.Ignore());

        CreateMap<VM.Archivos.ActualizarArchivoRequest, Ent.Archivo>();
    }
}