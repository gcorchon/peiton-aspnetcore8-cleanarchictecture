using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Bancos;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICredencialRepository))]
public class CredencialRepository : RepositoryBase<Credencial>, ICredencialRepository
{
    public CredencialRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<List<Credencial>> ObtenerCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter)
    {
        return ApplyFilters(DbSet.Include(c => c.EntidadFinanciera).Include("Tutelado.DatosJuridicos.Nombramiento"), filter)
                .OrderByDescending(c => c.UltimaEjecucionCorrecta)
                .ToListAsync();
    }

    public Task<List<Credencial>> ObtenerCredencialesBloqueadasAsync(int page, int total, CredencialesBloqueadasFilter filter)
    {
        return ApplyFilters(DbSet.Include(c => c.EntidadFinanciera).Include("Tutelado.DatosJuridicos.Nombramiento"), filter)
                .OrderByDescending(c => c.UltimaEjecucionCorrecta)
                .Skip((page - 1) * total)
                .Take(total)
                .AsNoTracking()
                .ToListAsync();
    }

    public Task<int> ContarCredencialesBloqueadasAsync(CredencialesBloqueadasFilter filter)
    {
        return ApplyFilters(DbSet.Include(c => c.EntidadFinanciera).Include("Tutelado.DatosJuridicos.Nombramiento"), filter).CountAsync();
    }

    private IQueryable<Credencial> ApplyFilters(IQueryable<Credencial> query, CredencialesBloqueadasFilter filter)
    {
        query = query.Where(c => !c.Tutelado.Muerto && (c.Reintentos == 10 || !c.DatosCorrectos) && !c.Baja && !c.DetenerRobot);

        if (!string.IsNullOrWhiteSpace(filter.Tutelado))
        {
            query = query.Where(c => c.Tutelado.NombreCompleto!.Contains(filter.Tutelado));
        }

        if (!string.IsNullOrWhiteSpace(filter.Dni))
        {
            query = query.Where(c => c.Tutelado.DNI!.StartsWith(filter.Dni));
        }

        if (!string.IsNullOrWhiteSpace(filter.NumeroExpediente))
        {
            query = query.Where(c => c.Tutelado.NumeroExpediente!.StartsWith(filter.NumeroExpediente));
        }

        if (!string.IsNullOrWhiteSpace(filter.EntidadFinanciera))
        {
            query = query.Where(c => c.EntidadFinanciera.Descripcion.Contains(filter.EntidadFinanciera));
        }

        if (!string.IsNullOrWhiteSpace(filter.UltimaEjecucion))
        {
            query = query.Where(c => c.UltimaEjecucion != null && DbContext.DateAsString(c.UltimaEjecucion.Value).Contains(filter.UltimaEjecucion));
        }

        if (!string.IsNullOrWhiteSpace(filter.UltimaEjecucionCorrecta))
        {
            query = query.Where(c => c.UltimaEjecucionCorrecta != null && DbContext.DateAsString(c.UltimaEjecucionCorrecta.Value).Contains(filter.UltimaEjecucionCorrecta));
        }

        return query;
    }

    public Task DesbloquearCredencialesAsync()
    {
        return this.DbContext.Database.ExecuteSqlAsync(@$"update credencial set DatosCorrectos=1, Reintentos=0, ProximaEjecucion=getdate()
                                                           from credencial inner join tutelado on pk_tutelado=fk_tutelado
                                                           where Tutelado.Muerto=0 and Credencial.Baja=0 and Credencial.DetenerRobot=0");
    }
}
