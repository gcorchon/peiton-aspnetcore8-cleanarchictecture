using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ApoyoInformalProfile : Profile
{
    public ApoyoInformalProfile()
    {
        CreateMap<Ent.ApoyoInformal, VM.ApoyosInformales.ApoyoInformalViewModel>();
    }
}