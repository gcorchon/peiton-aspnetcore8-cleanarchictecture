using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ContactoProfile : Profile
{
    public ContactoProfile()
    {
        CreateMap<Ent.Contacto, VM.Contactos.ContactoViewModel>();
    }
}