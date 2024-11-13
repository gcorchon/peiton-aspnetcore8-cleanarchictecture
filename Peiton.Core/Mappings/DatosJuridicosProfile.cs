using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class DatosJuridicosProfile : Profile
{
    public DatosJuridicosProfile()
    {
        CreateMap<Ent.DatosJuridicos, VM.DatosJuridicos.DatosJuridicosViewModel>()
            .ForMember(vm => vm.ProcedimientosAdicionales, opt => opt.MapFrom(dj => dj.Tutelado.ProcedimientosAdicionales))
            .ForMember(vm => vm.MedidasPenales, opt => opt.MapFrom(dj => dj.Tutelado.MedidasPenales))
            .ForMember(vm => vm.ObjetivosJuridicos, opt => opt.MapFrom(dj => dj.Tutelado.Objetivos.Where(o => o.TipoObjetivoId == 10)));
    }
}