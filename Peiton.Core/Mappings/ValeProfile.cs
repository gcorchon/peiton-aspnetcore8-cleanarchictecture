using AutoMapper;
using Peiton.Serialization;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ValeProfile : Profile
{
    public ValeProfile()
    {
        CreateMap<Ent.Vale, VM.Vales.ValeViewModel>();
        CreateMap<Ent.Vale, VM.Vales.ValeListItem>()
                .ForMember(vm => vm.Solicitante, m => m.MapFrom(t => t.Solicitante.NombreCompleto));

        CreateMap<Ent.Vale, VM.Vales.ValeViewModel>()
           .ForMember(vm => vm.Solicitante, m => m.MapFrom(t => t.Solicitante.NombreCompleto))
           .ForMember(vm => vm.Revisor, m => m.MapFrom(t => t.Revisor != null ? t.Revisor.NombreCompleto : null))
           .ForMember(vm => vm.Autorizador, m => m.MapFrom(t => t.Autorizador != null ? t.Autorizador.NombreCompleto : null))
           .ForMember(vm => vm.Archivos, m => m.MapFrom(t => t.Archivos != null ? t.Archivos.Deserialize<string[]>() : new string[] { }));
    }
}