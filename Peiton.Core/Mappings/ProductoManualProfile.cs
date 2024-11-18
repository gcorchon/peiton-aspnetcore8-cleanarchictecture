using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ProductoManualProfile : Profile
{
    public ProductoManualProfile()
    {
        CreateMap<Ent.ProductoManual, VM.ProductosBancarios.ProductoBancarioListItem>()
            .ForMember(vm => vm.Manual, opt => opt.MapFrom(p => true))
            .ForMember(vm => vm.TipoProducto, opt => opt.MapFrom(p => p.TipoProducto.Descripcion))
            .ForMember(vm => vm.Identificacion, opt => opt.MapFrom(p => p.Identificacion))
            .ForMember(vm => vm.EntidadFinanciera, opt => opt.MapFrom(p => p.EntidadFinanciera.Descripcion));

        CreateMap<Ent.ProductoManual, VM.ProductosBancarios.ProductoBancarioViewModel>();

        CreateMap<VM.ProductosBancarios.CrearProductoBancarioRequest, Ent.ProductoManual>();
        CreateMap<VM.ProductosBancarios.ProductoBancarioViewModel, Ent.ProductoManual>();


    }
}