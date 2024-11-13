using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuteladoDiagnosticoProfile : Profile
{
    public TuteladoDiagnosticoProfile()
    {
        CreateMap<Ent.TuteladoDiagnostico, VM.TuteladoDiagnosticos.TuteladoDiagnosticoViewModel>();
    }
}