using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuteladoSaludPsiquicaProfile : Profile
{
    public TuteladoSaludPsiquicaProfile()
    {
        CreateMap<Ent.TuteladoSaludPsiquica, VM.TuteladoSaludPsiquica.TuteladoSaludPsiquicaViewModel>();
    }
}