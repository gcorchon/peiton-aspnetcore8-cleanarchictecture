using AutoMapper;
using Microsoft.AspNetCore.Http;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;
using Peiton.Core.Utils;

namespace Peiton.Core.Mappings;
public class InformePersonalProfile : Profile
{
    public InformePersonalProfile()
    {
        CreateMap<Ent.InformePersonal, VM.InformesPersonales.InformePersonalListItem>()
            .ForMember(vm => vm.Usuario, opt => opt.MapFrom(o => o.Usuario.NombreCompleto));
    }
}