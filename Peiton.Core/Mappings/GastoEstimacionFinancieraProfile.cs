using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class GastoEstimacionFinancieraProfile : Profile
{
    public GastoEstimacionFinancieraProfile()
    {
        CreateMap<Ent.GastoEstimacionFinanciera, VM.GastosEstimacionFinanciera.GastoEstimacionFinancieraViewModel>();
    }
}