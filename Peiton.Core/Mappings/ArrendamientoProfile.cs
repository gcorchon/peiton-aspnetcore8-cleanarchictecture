using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ArrendamientoProfile : Profile
{
    public ArrendamientoProfile()
    {
        CreateMap<Ent.Arrendamiento, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, opt => opt.MapFrom(i => i.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(i => !string.IsNullOrWhiteSpace(i.DireccionCompleta) ? i.DireccionCompleta.Trim() : null));

        CreateMap<Ent.Arrendamiento, VM.Arrendamientos.ArrendamientoListItem>();

        CreateMap<Ent.Arrendamiento, VM.Arrendamientos.ArrendamientoViewModel>().ReverseMap();
        CreateMap<VM.Arrendamientos.CrearArrendamientoRequest, Ent.Arrendamiento>();
    }
}