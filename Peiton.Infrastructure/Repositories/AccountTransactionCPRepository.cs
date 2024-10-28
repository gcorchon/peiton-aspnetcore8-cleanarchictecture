using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.MovimientosPendientesBanco;
using Peiton.DependencyInjection;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IAccountTransactionCPRepository))]
public class AccountTransactionCPRepository : RepositoryBase<AccountTransactionCP>, IAccountTransactionCPRepository
{
    public AccountTransactionCPRepository(PeitonDbContext dbContext) : base(dbContext)
    {

    }



    public Task<AccountTransactionCP[]> ObtenerMovimientosPendientesBancoAsync(int page, int total, MovimientosPendientesBancoFilter filter)
    {
        IQueryable<AccountTransactionCP> query = this.DbSet
                         .Include(at => at.AccountCP);
        //.Include(at => at.AccountCP.CredencialCP)
        //.Include(at => at.AccountCP.CredencialCP.EntidadFinanciera)
        //.Include(at => at.Asientos);

        query = ApplyFilter(query, filter);

        return query
                    .OrderByDescending(act => act.OperationDate)
                    .Skip((page - 1) * total)
                    .Take(total)
                    .AsNoTracking()
                    .ToArrayAsync();
    }

    public Task<int> ContarMovimientosPendientesBancoAsync(MovimientosPendientesBancoFilter filter)
    {
        IQueryable<AccountTransactionCP> query = this.DbSet;
        //.Include(at => at.AccountCP.CredencialCP)
        //.Include(at => at.AccountCP.CredencialCP.EntidadFinanciera)
        //.Include(at => at.Asientos);

        query = ApplyFilter(query, filter);

        return query.CountAsync();
    }

    private IQueryable<AccountTransactionCP> ApplyFilter(IQueryable<AccountTransactionCP> query, MovimientosPendientesBancoFilter filter)
    {
        if (filter == null) return query;

        if (filter.Cuenta.HasValue)
        {
            query = query.Where(act => act.AccountCPId == filter.Cuenta.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Description))
        {
            query = query.Where(act => act.Description.Contains(filter.Description));
        }

        if (!string.IsNullOrWhiteSpace(filter.Reference))
        {
            query = query.Where(act => act.Reference.Contains(filter.Reference));
        }

        if (!string.IsNullOrWhiteSpace(filter.Payer))
        {
            query = query.Where(act => act.Payer == filter.Payer);
        }

        if (!string.IsNullOrWhiteSpace(filter.Payee))
        {
            query = query.Where(act => act.Payee == filter.Payee);
        }

        if (!string.IsNullOrWhiteSpace(filter.Quantity))
        {
            query = query.Where(act => this.DbContext.DecimalAsString(act.Quantity).StartsWith(filter.Quantity));
        }

        if (!string.IsNullOrWhiteSpace(filter.OperationDate))
        {
            query = query.Where(act => this.DbContext.DateAsString(act.OperationDate).Contains(filter.OperationDate));
        }

        if (filter.Pendientes.HasValue)
        {
            if (filter.Pendientes.Value)
            {
                query = query
                    .Include(at => at.Asientos)
                    .Where(act => !act.Ocultar && act.Asientos.Sum(a => a.Importe) != act.Quantity);
            }
            else
            {
                query = query
                    .Include(at => at.Asientos)
                    .Where(act => !act.Ocultar && act.Asientos.Sum(a => a.Importe) == act.Quantity);
            }
        }

        return query;
    }
}
