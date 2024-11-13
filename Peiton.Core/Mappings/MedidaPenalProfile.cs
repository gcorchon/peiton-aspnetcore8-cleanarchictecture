using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class MedidaPenalProfile : Profile
{
    public MedidaPenalProfile()
    {
        CreateMap<Ent.MedidaPenal, VM.MedidasPenales.MedidaPenalViewModel>();
    }
}