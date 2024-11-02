using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<Ent.Categoria, VM.Categorias.CategoriaViewModel>();
    }
}