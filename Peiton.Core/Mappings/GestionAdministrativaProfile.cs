using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class GestionAdministrativaProfile : Profile
{
    public GestionAdministrativaProfile()
    {
        CreateMap<Ent.GestionAdministrativa, VM.GestoresAdministrativos.GestionAdministrativaListItem>()
                    .ForMember(vm => vm.Tutelado, m => m.MapFrom(o => o.Tutelado.NombreCompleto))
                    .ForMember(vm => vm.Trabajador, m => m.MapFrom(o => o.Usuario.NombreCompleto))
                    .ForMember(vm => vm.Tipo, m => m.MapFrom(o => o.GestionAdministrativaTipo.Descripcion))
                    .ForMember(vm => vm.Estado, m => m.MapFrom(o => this.GetDescripcionEstadoGestionAdministrativa(o.Estado)));

        CreateMap<Ent.GestionAdministrativa, VM.GestoresAdministrativos.GestionAdministrativaViewModel>()
            .ForMember(vm => vm.Solicitada, m => m.MapFrom(o => (o.Estado & 2) > 0))
            .ForMember(vm => vm.Designada, m => m.MapFrom(o => (o.Estado & 4) > 0))
            .ForMember(vm => vm.Finalizada, m => m.MapFrom(o => (o.Estado & 8) > 0));
    }

    private string GetDescripcionEstadoGestionAdministrativa(int estado)
    {
        if ((estado & 8) > 0) return "Finalizada";
        if ((estado & 4) > 0) return "Designada";
        if ((estado & 2) > 0) return "Solicitada";
        if ((estado & 1) > 0) return "Pendiente";
        return "Pendiente";
    }
}