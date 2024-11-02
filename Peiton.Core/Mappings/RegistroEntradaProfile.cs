using System.Xml.Linq;
using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class RegistroEntradaProfile : Profile
{
    public RegistroEntradaProfile()
    {
        CreateMap<Ent.RegistroEntrada, VM.Visitas.RegistroEntradaListItem>()
                    .ForMember(r => r.Visitante, opt => opt.MapFrom(o => o.Nombre))
                    .ForMember(r => r.Visitado, opt => opt.MapFrom(o => GetVisitantePrincipal(o.Personas)));

        CreateMap<Ent.RegistroEntrada, VM.Visitas.RegistroEntradaViewModel>()
            .ForMember(r => r.Visitante, opt => opt.MapFrom(o => new VM.Visitas.Visitante() { Dni = o.Dni, Nombre = o.Nombre, Tutelado = o.Tutelado }))
            .ForMember(r => r.Visitadas, opt => opt.MapFrom(o => GetVisitadas(o.Personas)));
    }

    private VM.Visitas.Visitado[] GetVisitadas(string personas)
    {
        var doc = XDocument.Parse(personas);
        var visitantes = doc.Root!.Elements("Visitado").Select(v => new VM.Visitas.Visitado() { Nombre = v.Element("Nombre")!.Value });
        return visitantes.ToArray();
    }

    private string? GetVisitantePrincipal(string personas)
    {
        var doc = XDocument.Parse(personas);
        var visitantes = doc.Root!.Elements("Visitado").Select(v => v.Element("Nombre")!.Value);

        var total = visitantes.Count();
        if (total > 0)
        {
            var principal = visitantes.First();
            return total > 1 ? $"{principal} (+ {total - 1})" : principal;
        }

        return null;
    }
}