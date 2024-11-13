using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DatosSocialesProfile : Profile
{
    public DatosSocialesProfile()
    {
        CreateMap<Ent.DatosSociales, VM.DatosSociales.DatosSocialesViewModel>()
            .ForMember(vm => vm.Diagnosticos, opt => opt.MapFrom(d => d.Tutelado.TuteladosDiagnosticos))
            .ForMember(vm => vm.Objetivos, opt => opt.MapFrom(d => d.Tutelado.Objetivos))
            .ForMember(vm => vm.TiposDiscapacidad, opt => opt.MapFrom(d => d.Tutelado.DiscapacidadesTipos.Select(t => t.Id)))
            .ForMember(vm => vm.ServiciosDiscapacidad, opt => opt.MapFrom(d => d.Tutelado.DiscapacidadesServicios.Select(t => t.Id)))
            .ForMember(vm => vm.PvssDiscapacidad, opt => opt.MapFrom(d => d.Tutelado.DiscapacidadesPVSs.Select(t => t.Id)))
            .ForMember(vm => vm.RegistrosSaludFisica, opt => opt.MapFrom(d => d.Tutelado.RegistrosSaludFisica))
            .ForMember(vm => vm.RegistrosSaludPsiquica, opt => opt.MapFrom(d => d.Tutelado.RegistrosSaludPsiquica))
            .ForMember(vm => vm.AdiccionesComportamentales, opt => opt.MapFrom(d => d.Tutelado.AdiccionesComportamentales.Select(t => t.Id)))
            .ForMember(vm => vm.AdiccionesSustancias, opt => opt.MapFrom(d => d.Tutelado.AdiccionesSustancias.Select(t => t.Id)))
            .ForMember(vm => vm.ApoyosFormales, opt => opt.MapFrom(d => d.Tutelado.ApoyosFormales))
            .ForMember(vm => vm.ApoyosInformales, opt => opt.MapFrom(d => d.Tutelado.ApoyosInformales))
            .ForMember(vm => vm.GastosEstimacionesFinancieras, opt => opt.MapFrom(d => d.Tutelado.GastosEstimacionesFinancieras))
            .ForMember(vm => vm.IngresosEstimacionesFinancieras, opt => opt.MapFrom(d => d.Tutelado.IngresosEstimacionesFinancieras));
    }
}