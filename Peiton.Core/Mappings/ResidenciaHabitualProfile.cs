using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ResidenciaHabitualProfile : Profile
{
    public ResidenciaHabitualProfile()
    {
        CreateMap<Ent.ResidenciaHabitual, VM.ResidenciasHabituales.ResidenciaHabitualViewModel>();

    }
}