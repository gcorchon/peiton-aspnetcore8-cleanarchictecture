using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AccountTransactionCPProfile : Profile
{
    public AccountTransactionCPProfile()
    {
        CreateMap<Ent.AccountTransactionCP, VM.MovimientosPendientesBanco.MovimientoPendienteBancoListItem>()
            .ForMember(vm => vm.AccountCPName, opt => opt.MapFrom(obj => obj.AccountCP.WebAlias));

        CreateMap<Ent.AccountTransactionCP, VM.MovimientosPendientesBanco.MovimientoPendienteBancoViewModel>()
            .ForMember(vm => vm.WebAlias, opt => opt.MapFrom(obj => obj.AccountCP.WebAlias))
            .ForMember(vm => vm.Iban, opt => opt.MapFrom(obj => obj.AccountCP.Iban));

    }

}
