using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SueldoPensionProfile : Profile
{
    public SueldoPensionProfile()
    {
        CreateMap<Ent.SueldoPension, VM.SueldosPensiones.SueldoPensionListItem>();
        CreateMap<VM.SueldosPensiones.CrearSueldoPensionRequest, Ent.SueldoPension>();
        CreateMap<VM.SueldosPensiones.ActualizarSueldoPensionRequest, Ent.SueldoPension>();
    }
}