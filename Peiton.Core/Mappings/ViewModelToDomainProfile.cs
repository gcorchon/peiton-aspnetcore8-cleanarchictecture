using AutoMapper;

using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings
{
    public class ViewModelToDomainProfile : Profile
    {

        public ViewModelToDomainProfile()
        {
            CreateMap<VM.Capitulo.CreateCapituloRequest, Ent.Capitulo>();
            CreateMap<VM.Partida.CreatePartidaRequest, Ent.Partida>();
        }
    }
}