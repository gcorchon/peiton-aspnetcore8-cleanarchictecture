using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class FacturaProfile : Profile
{
    public FacturaProfile()
    {
        CreateMap<Ent.Factura, VM.Facturas.FacturaViewModel>();

        CreateMap<Ent.Factura, VM.Facturas.FacturaListItem>()
            .ForMember(vm => vm.EstadoInicial, opt => opt.MapFrom(obj => obj.EstadoInicial.HasValue ? VM.Facturas.EstadoFactura.GetText(obj.EstadoInicial.Value) : null))
            .ForMember(vm => vm.EstadoContable, opt => opt.MapFrom(obj => obj.EstadoContable.HasValue ? VM.Facturas.EstadoFactura.GetText(obj.EstadoContable.Value) : null));
    }
}