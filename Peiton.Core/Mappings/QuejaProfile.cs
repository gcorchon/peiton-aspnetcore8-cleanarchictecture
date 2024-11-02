using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class QuejaProfile : Profile
{
    public QuejaProfile()
    {
        CreateMap<Ent.Queja, VM.Quejas.QuejaViewModel>()
            .ForMember(vm => vm.QuejaMotivos, m => m.MapFrom(o => o.QuejasMotivos.Select(t => t.Id).ToArray()));

        CreateMap<Ent.Queja, VM.Quejas.QuejaListItem>()
            .ForMember(vm => vm.Denunciante, m => m.MapFrom(o => o.NombreDenunciante ?? o.Tutelado.NombreCompleto))
            .ForMember(vm => vm.TipoDenunciante, m => m.MapFrom(o => o.QuejaTipoDenunciante.Descripcion));
    }
}