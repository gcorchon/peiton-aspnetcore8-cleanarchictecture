using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Ent.Company, VM.Companies.CompanyViewModel>()
            .ForMember(vm => vm.DescripcionCnae2009, opt => opt.MapFrom(o => o.Cnae2009Navigation.Description))
            .ForMember(vm => vm.Categoria, opt => opt.MapFrom(o => o.Cnae2009Navigation.Categoria != null ? o.Cnae2009Navigation.Categoria.Descripcion : null));
    }
}