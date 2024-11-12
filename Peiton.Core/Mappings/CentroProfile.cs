using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CentroProfile : Profile
{
    public CentroProfile()
    {
        CreateMap<Ent.Centro, VM.Centros.CentroListItem>();
        CreateMap<Ent.Centro, VM.Centros.CentroViewModel>();
        CreateMap<Ent.Centro, VM.Common.ListItem>()
            .ForMember(v => v.Value, opt => opt.MapFrom(c => c.Id))
            .ForMember(v => v.Text, opt => opt.MapFrom(c => c.Nombre));

        CreateMap<Ent.Centro, VM.Centros.CentroResidenciaHabitual>()
            .ForMember(v => v.Telefono, opt => opt.MapFrom(c => c.Telefono1 ?? c.Telefono2));
    }
}