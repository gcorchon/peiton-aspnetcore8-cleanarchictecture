using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CredencialProfile : Profile
{
    public CredencialProfile()
    {
        CreateMap<Ent.Credencial, VM.Credenciales.CredencialBloquedaListItem>()
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(c => c.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.Tutelado, opt => opt.MapFrom(c => c.Tutelado.NombreCompleto))
            .ForMember(vm => vm.Dni, opt => opt.MapFrom(c => c.Tutelado.DNI))
            .ForMember(vm => vm.NumeroExpediente, opt => opt.MapFrom(c => c.Tutelado.NumeroExpediente))
            .ForMember(vm => vm.Nombramiento, opt => opt.MapFrom(c => c.Tutelado.DatosJuridicos != null && c.Tutelado.DatosJuridicos.Nombramiento != null ? c.Tutelado.DatosJuridicos.Nombramiento.Descripcion : null));


        CreateMap<Ent.Credencial, VM.Credenciales.CredencialListItem>()
            .ForMember(vm => vm.EntidadFinancieraId, opt => opt.MapFrom(c => c.EntidadFinancieraId))
            .ForMember(vm => vm.EntidadFinancieraCssClass, opt => opt.MapFrom(c => c.EntidadFinanciera.CssClass))
            .ForMember(vm => vm.Campos, opt => opt.MapFrom(c => CredencialHelper.ObtenerCampos(c.EntidadFinanciera.Campos, c.DatosConexion)));

        CreateMap<Ent.Credencial, VM.Credenciales.CredencialPosicionGlobal>()
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(o => o.EntidadFinanciera.Descripcion))
            .ForMember(vm => vm.EntidadFinancieraCssClass, opt => opt.MapFrom(o => o.EntidadFinanciera.CssClass))
            .ForMember(vm => vm.Ok, opt => opt.MapFrom(o => o.Reintentos == 0 && o.DatosCorrectos));
    }

}