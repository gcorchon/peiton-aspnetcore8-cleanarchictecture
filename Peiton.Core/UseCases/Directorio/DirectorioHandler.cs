using Peiton.Contracts.Directorio;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Directorio;

[Injectable]
public class DirectorioHandler(IDirectorioAMTARepository directorioAMTARepository)
{
    public async Task<DirectorioAMTA[]> HandleAsync(DirectorioFilter filter)
    {
        return await directorioAMTARepository.ObtenerDirectorioAsync(filter);
    }
}