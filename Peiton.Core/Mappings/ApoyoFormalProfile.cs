using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ApoyoFormalProfile : Profile
{
    public ApoyoFormalProfile()
    {
        CreateMap<Ent.ApoyoFormal, VM.ApoyosFormales.ApoyoFormalViewModel>();
    }
}