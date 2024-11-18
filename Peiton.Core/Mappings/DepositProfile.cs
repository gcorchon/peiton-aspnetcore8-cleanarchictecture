using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DepositProfile : Profile
{
    public DepositProfile()
    {
        CreateMap<Ent.Deposit, VM.ProductosBancarios.ProductoBancarioListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => false))
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Depósito"))
            .ForMember(vm => vm.TipoProducto, opt => opt.MapFrom(p => "Depósito"))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.Credencial.EntidadFinanciera.Descripcion));

        CreateMap<Ent.Deposit, VM.ProductosBancarios.ProductoBancarioViewModel>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Depósito"))
            .ForMember(vm => vm.TipoProductoId, opt => opt.MapFrom(p => 3))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber));

        CreateMap<VM.ProductosBancarios.ActualizarProductoBancarioRobotRequest, Ent.Deposit>();
    }
}