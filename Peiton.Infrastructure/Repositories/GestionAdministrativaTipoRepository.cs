using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;
using Peiton.Contracts.GestoresAdministrativos;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{

    [Injectable(typeof(IGestionAdministrativaTipoRepository))]
    public class GestionAdministrativaTipoRepository : RepositoryBase<GestionAdministrativaTipo>, IGestionAdministrativaTipoRepository
    {
        public GestionAdministrativaTipoRepository(PeitonDbContext dbContext) : base(dbContext)
        {

        }
    }
}