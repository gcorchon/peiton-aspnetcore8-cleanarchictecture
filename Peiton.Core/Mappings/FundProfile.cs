using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class FundProfile : Profile
{
    public FundProfile()
    {
        CreateMap<Ent.Fund, VM.ProductosBancarios.ProductoBancarioListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => false))
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Fondo"))
            .ForMember(vm => vm.TipoProducto, opt => opt.MapFrom(p => "Fondo"))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.Credencial.EntidadFinanciera));

        CreateMap<Ent.Fund, VM.ProductosBancarios.ProductoBancarioViewModel>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Fondo"))
            .ForMember(vm => vm.TipoProductoId, opt => opt.MapFrom(p => 2))
            .ForMember(vm => vm.EntidadFinancieraId, opt => opt.MapFrom(p => p.Credencial.EntidadFinancieraId))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber));

        CreateMap<VM.ProductosBancarios.ActualizarProductoBancarioRobotRequest, Ent.Fund>();

        CreateMap<Ent.Fund, VM.ProductosBancarios.ProductoBancarioPosicionGlobalViewModel>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Fondo"))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber))
            .ForMember(vm => vm.UltimaActualizacion, opt => opt.MapFrom(p => p.FechaSaldo));
    }
}