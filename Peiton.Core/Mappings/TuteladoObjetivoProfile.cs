using AutoMapper;
using Peiton.Contracts.TuteladoObjetivos;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class TuteladoObjetivoProfile : Profile
{
    public TuteladoObjetivoProfile()
    {
        CreateMap<Ent.TuteladoObjetivo, VM.TuteladoObjetivos.TuteladoObjetivoViewModel>()
            .ForMember(vm => vm.Tareas, opt => opt.MapFrom(to => to.Tareas.Deserialize<TareaViewModel[]>()));

        CreateMap<VM.TuteladoObjetivos.GuardarObjetivosRequest, Ent.TuteladoObjetivo>()
            .ForMember(to => to.Tareas, opt => opt.MapFrom(vm => vm.Tareas.ToXDocument()!.ToString()));
    }
}