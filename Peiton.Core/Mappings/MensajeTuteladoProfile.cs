using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class MensajeTuteladoProfile : Profile
{
    public MensajeTuteladoProfile()
    {
        CreateMap<Ent.MensajeTutelado, VM.MensajesTuAppoyo.MensajeTuAppoyoViewModel>();
    }
}