using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DatosJuridicosProfile : Profile
{
    public DatosJuridicosProfile()
    {
        CreateMap<Ent.DatosJuridicos, VM.DatosJuridicos.DatosJuridicosViewModel>();
    }
}