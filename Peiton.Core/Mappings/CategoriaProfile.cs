using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<Ent.Categoria, VM.Categorias.CategoriaViewModel>();

        CreateMap<Ent.Categoria, VM.Common.ListItem>()
            .ForMember(vm => vm.Text, opt => opt.MapFrom(c => c.Descripcion))
            .ForMember(vm => vm.Id, opt => opt.MapFrom(c => c.Id));
    }
}