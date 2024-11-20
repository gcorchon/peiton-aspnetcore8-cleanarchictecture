using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TareaAgendaProfile : Profile
{
    public TareaAgendaProfile()
    {
        CreateMap<Ent.TareaAgenda, VM.Seguimientos.TareaAgendaViewModel>();
    }
}