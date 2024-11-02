using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VehiculoEntidadReservaProfile : Profile
{
    public VehiculoEntidadReservaProfile()
    {

        CreateMap<Ent.VehiculoEntidadReserva, VM.VehiculosEntidad.VehiculoEntidadReservaViewModel>()
            .ForMember(r => r.Propia, opt => opt.MapFrom((src, dest, destMember, context) => (int)context.Items["UserId"] == src.UsuarioId))
            .ForMember(r => r.Usuario, opt => opt.MapFrom(v => v.Usuario.NombreCompleto));
    }
}