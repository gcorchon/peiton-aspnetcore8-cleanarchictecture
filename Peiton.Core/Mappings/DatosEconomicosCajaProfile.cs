using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DatosEconomicosCajaProfile : Profile
{
    public DatosEconomicosCajaProfile()
    {
        CreateMap<Ent.DatosEconomicosCaja, VM.DatosEconomicosCajaFuerte.DatosEconomicosCajaViewModel>().ReverseMap();
    }
}