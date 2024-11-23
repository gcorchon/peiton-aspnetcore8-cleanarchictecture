using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AccountTransactionProfile : Profile
{
    public AccountTransactionProfile()
    {
        CreateMap<Ent.AccountTransaction, VM.AccountTransactions.AccountTransactionListItem>();
    }
}