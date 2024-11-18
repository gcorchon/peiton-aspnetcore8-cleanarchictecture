using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ShareProfile : Profile
{
    public ShareProfile()
    {
        CreateMap<Ent.Share, VM.ProductosBancarios.ProductoBancarioListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => false))
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Cuenta de valores"))
            .ForMember(vm => vm.TipoProducto, opt => opt.MapFrom(p => "Cuenta de valores"))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.Credencial.EntidadFinanciera.Descripcion));

        CreateMap<Ent.Share, VM.ProductosBancarios.ProductoBancarioViewModel>()
            .ForMember(vm => vm.Nombre, opt => opt.MapFrom(p => p.WebAlias ?? "Cuenta de valores"))
            .ForMember(vm => vm.TipoProductoId, opt => opt.MapFrom(p => 4))
            .ForMember(vm => vm.EntidadFinancieraId, opt => opt.MapFrom(p => p.Credencial.EntidadFinancieraId))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.AccountNumber));

        CreateMap<VM.ProductosBancarios.ActualizarProductoBancarioRobotRequest, Ent.Share>();
    }
}