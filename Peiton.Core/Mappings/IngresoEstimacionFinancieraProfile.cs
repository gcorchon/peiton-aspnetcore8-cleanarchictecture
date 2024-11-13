using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class IngresoEstimacionFinancieraProfile : Profile
{
    public IngresoEstimacionFinancieraProfile()
    {
        CreateMap<Ent.IngresoEstimacionFinanciera, VM.IngresosEstimacionFinanciera.IngresoEstimacionFinancieraViewModel>();
    }
}