using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DatosEconomicosProfile : Profile
{
    public DatosEconomicosProfile()
    {
        CreateMap<Ent.DatosEconomicos, VM.DatosEconomicos.DatosEconomicosViewModel>();
    }
}