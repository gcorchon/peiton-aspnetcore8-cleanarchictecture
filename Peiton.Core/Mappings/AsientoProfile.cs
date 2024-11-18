using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AsientoProfile : Profile
{
    public AsientoProfile()
    {
        CreateMap<Ent.Asiento, VM.Asientos.AsientoViewModel>()
            .ForMember(vm => vm.CapituloId, opt => opt.MapFrom(obj => obj.Partida != null ? obj.Partida.CapituloId : (int?)null))
            .ForMember(vm => vm.FacturaIds, opt => opt.MapFrom(obj => obj.Facturas.Select(f => f.Id)));

        CreateMap<Ent.Asiento, VM.Asientos.AsientoHuerfanoListItem>()
            .ForMember(vm => vm.Partida, opt => opt.MapFrom(obj => obj.Partida!.Numero))
            .ForMember(vm => vm.Capitulo, opt => opt.MapFrom(obj => obj.Partida!.Capitulo!.Numero));

        CreateMap<Ent.Asiento, VM.Asientos.AsientoListItem>()
            .ForMember(vm => vm.Partida, opt => opt.MapFrom(obj => obj.Partida!.Numero))
            .ForMember(vm => vm.Capitulo, opt => opt.MapFrom(obj => obj.Partida!.Capitulo!.Numero))
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.CajaAMTAId != null ? "C" : (obj.AccountTransactionCPId != null ? "B" : "")))
            .ForMember(vm => vm.IngresoGasto, opt => opt.MapFrom(obj => obj.TipoMovimiento == 1 ? "G" : "I"));


        CreateMap<Ent.Asiento, VM.Asientos.AsientoFondoTuteladoListItem>()
            .ForMember(vm => vm.Tipo, opt => opt.MapFrom(obj => obj.CajaAMTAId != null ? "C" : (obj.AccountTransactionCPId != null ? "B" : "")));
    }
}