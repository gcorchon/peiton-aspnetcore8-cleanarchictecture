
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Abogados;

[Injectable]
public class AbogadosSenalamientosHandler(IAbogadoRepository abogadoRepository)
{
    public async Task<List<Abogado>> HandleAsync(string nombre)
    {
        return await abogadoRepository.AbogadosParaSenalamientoAsync(nombre);
    }
}