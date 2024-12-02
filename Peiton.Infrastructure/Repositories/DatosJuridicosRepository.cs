using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosJuridicosRepository))]
public class DatosJuridicosRepository(PeitonDbContext dbContext) : RepositoryBase<DatosJuridicos>(dbContext), IDatosJuridicosRepository
{
}
