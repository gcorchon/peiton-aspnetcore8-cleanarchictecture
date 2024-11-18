using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Ent.Account, VM.Caja.Cuenta>();

        CreateMap<Ent.Account, VM.ProductosBancarios.ProductoBancarioListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => false))
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Libreta"))
            .ForMember(vm => vm.TipoProducto, opt => opt.MapFrom(p => "Libreta"))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.Iban))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.Credencial.EntidadFinanciera.Descripcion));

        CreateMap<Ent.Account, VM.ProductosBancarios.ProductoBancarioViewModel>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Libreta"))
            .ForMember(vm => vm.TipoProductoId, opt => opt.MapFrom(p => 1))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.Iban));

        CreateMap<VM.ProductosBancarios.ActualizarProductoBancarioRobotRequest, Ent.Account>();

    }
}