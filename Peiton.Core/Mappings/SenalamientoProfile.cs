using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SenalamientoProfile : Profile
{
    public SenalamientoProfile()
    {
        CreateMap<Ent.Senalamiento, VM.Senalamientos.SenalamientoListItem>()
            .ForMember(s => s.Asistente, opt => opt.MapFrom(o => o.AbogadoAsistente != null ? o.AbogadoAsistente!.Nombre : o.ProfesionalAsistente));

        CreateMap<Ent.Senalamiento, VM.Senalamientos.SenalamientoViewModel>();
    }
}