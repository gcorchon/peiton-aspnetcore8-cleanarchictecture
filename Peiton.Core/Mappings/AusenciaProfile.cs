using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AusenciaProfile : Profile
{
    public AusenciaProfile()
    {
        CreateMap<Ent.Ausencia, VM.Ausencias.AusenciaViewModel>();
    }
}