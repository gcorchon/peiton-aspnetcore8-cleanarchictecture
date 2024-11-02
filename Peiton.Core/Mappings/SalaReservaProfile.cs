using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SalaReservaProfile : Profile
{
    public SalaReservaProfile()
    {
        CreateMap<Ent.SalaReserva, VM.Salas.ReservaViewModel>()
            .ForMember(r => r.Propia, opt => opt.MapFrom((src, dest, destMember, context) => (int)context.Items["UserId"] == src.UsuarioId))
            .ForMember(s => s.Usuario, opt => opt.MapFrom(s => s.Usuario.NombreCompleto));
    }
}