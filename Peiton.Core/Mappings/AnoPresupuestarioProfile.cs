using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AnoPresupuestarioProfile : Profile
{
    public AnoPresupuestarioProfile()
    {
        CreateMap<Ent.AnoPresupuestario, VM.AnoPresupuestario.AnoPresupuestarioViewModel>();
    }

}
