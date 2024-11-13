using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuteladoSaludFisicaProfile : Profile
{
    public TuteladoSaludFisicaProfile()
    {
        CreateMap<Ent.TuteladoSaludFisica, VM.TuteladoSaludFisica.TuteladoSaludFisicaViewModel>();
    }
}