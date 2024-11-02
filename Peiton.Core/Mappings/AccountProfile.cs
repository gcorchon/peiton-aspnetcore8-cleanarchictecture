using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Ent.Account, VM.Caja.Cuenta>();
    }
}