using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Quejas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaRepository))]
public class QuejaRepository : RepositoryBase<Queja>, IQuejaRepository
{
    public QuejaRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }

    public Task<int> ContarQuejasAsync(QuejasFilter filter)
    {
        var query = ApplySearchFilters(this.DbSet, filter);
        return query.CountAsync();
    }

    public Task<Queja[]> ObtenerQuejasAsync(int page, int total, QuejasFilter filter)
    {
        IQueryable<Queja> query = this.DbSet.Include("Tutelado")
                                      .Include("QuejaTipoDenunciante");
        return ApplySearchFilters(query, filter)
                     .OrderByDescending(q => q.Id)
                     .Skip((page - 1) * total)
                     .Take(total)
                     .AsNoTracking()
                     .ToArrayAsync();
    }

    private IQueryable<Queja> ApplySearchFilters(IQueryable<Queja> query, QuejasFilter filter)
    {
        if (filter == null) return query;


        if (!string.IsNullOrWhiteSpace(filter.Expediente))
        {
            query = query.Where(v => v.Expediente.Contains(filter.Expediente));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaCierre))
        {
            query = query.Where(a => a.FechaCierre != null && this.DbContext.DateAsString(a.FechaCierre.Value).Contains(filter.FechaCierre));
        }

        if (!string.IsNullOrWhiteSpace(filter.FechaEntrada))
        {
            query = query.Where(a => this.DbContext.DateAsString(a.FechaEntrada).Contains(filter.FechaEntrada));
        }

        if (!string.IsNullOrWhiteSpace(filter.Denunciante))
        {
            query = query.Where(v => (v.NombreDenunciante != null && v.NombreDenunciante.Contains(filter.Denunciante)) || v.Tutelado.NombreCompleto!.Contains(filter.Denunciante));
        }

        if (filter.TipoDenuncianteId.HasValue)
        {
            query = query.Where(v => v.QuejaTipoDenuncianteId == filter.TipoDenuncianteId.Value);
        }

        if (filter.ActuacionPendiente.HasValue)
        {
            query = query.Where(v => v.ActuacionPendiente == filter.ActuacionPendiente.Value);
        }

        if (filter.DiasTranscurridos.HasValue)
        {
            query = query.Where(v => v.DiasTranscurridos == filter.DiasTranscurridos.Value);
        }

        return query;

    }

    public Task<string> ObtenerSiguienteNumeroExpedienteAsync(int quejaTipoId)
    {

        var result = this.DbContext.Database.SqlQuery<string>(@$"declare @nomenclatura nvarchar(10)
                        declare @last int
                        declare @next int
                        declare @year varchar(2)

                        set @year = SUBSTRING(convert(varchar, YEAR(GETDATE())), 3, 4)
                        select @nomenclatura = Nomenclatura from QuejaTipo where Pk_QuejaTipo={quejaTipoId}

                        select @last = MAX(convert(int, SUBSTRING(expediente, LEN(@nomenclatura) + 2, CHARINDEX('/', expediente) - LEN(@nomenclatura) - 2))) 
                        from Queja where Fk_QuejaTipo={quejaTipoId} and SUBSTRING(expediente, LEN(expediente)-1, 2)=@year

                        set @next = coalesce(@last, 0) + 1

                        select @nomenclatura + ' ' + convert(varchar, @next) + '/' + @year").AsEnumerable().Single();

        return Task.FromResult(result);
    }
}
