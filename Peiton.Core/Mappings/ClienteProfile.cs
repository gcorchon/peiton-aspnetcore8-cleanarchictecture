using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Ent.Cliente, VM.Common.ListItem>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(obj => obj.Id))
            .ForMember(vm => vm.Text, opt => opt.MapFrom(obj => obj.Nombre));

        CreateMap<Ent.Cliente, VM.Clientes.ClienteListItem>();
    }
}