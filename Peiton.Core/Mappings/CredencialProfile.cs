using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CredencialProfile : Profile
{
    public CredencialProfile()
    {
        CreateMap<Ent.Credencial, VM.Bancos.CredencialBloquedaListItem>()
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(c => c.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(c => c.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(c => c.Tutelado.DNI))
            .ForMember(vm => vm.NumeroExpediente, opt => opt.MapFrom(c => c.Tutelado.NumeroExpediente))
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(c => c.Tutelado.DatosJuridicos != null && c.Tutelado.DatosJuridicos.Nombramiento != null ? c.Tutelado.DatosJuridicos.Nombramiento.Descripcion : null));

    }
}