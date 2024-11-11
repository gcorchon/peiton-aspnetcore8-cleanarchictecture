using AutoMapper;
using Peiton.Contracts.Directorio;
using Peiton.Core.Entities;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DirectorioAMTAProfile : Profile
{
    public DirectorioAMTAProfile()
    {
        CreateMap<Ent.DirectorioAMTA, VM.Directorio.DirectorioListItem>();
    }
}