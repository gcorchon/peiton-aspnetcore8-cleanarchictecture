using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.AccountTransactions;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAccountTransactionRepository))]
public class AccountTransactionRepository : RepositoryBase<AccountTransaction>, IAccountTransactionRepository
{
	public AccountTransactionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<int> ContarAccountTransactionsAsync(int accountId, AccountTransactionsFilter filter)
	{
		return ApplyFilters(DbSet, accountId, filter).CountAsync();
	}

	public Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(int page, int total, int accountId, AccountTransactionsFilter filter)
	{
		return ApplyFilters(DbSet, accountId, filter)
			.OrderByDescending(s => s.OperationDate).ThenByDescending(s => s.Id)
			.Skip((page - 1) * total)
			.Take(total)
			.AsNoTracking()
			.ToArrayAsync();
	}

	public Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(IEnumerable<int> accountTransactionIds)
	{
		return DbSet.Where(a => accountTransactionIds.Contains(a.Id)).ToArrayAsync();
	}

	public Task<AccountTransaction[]> ObtenerAccountTransactionsAsync(int accountId, DateTime desde, DateTime hasta)
	{
		return DbSet.Include(a => a.Categoria)
				.Where(c => c.AccountId == accountId && c.OperationDate >= desde && c.OperationDate <= hasta)
				.OrderBy(a => a.OperationDate).ThenBy(a => a.Id)
				.AsNoTracking()
				.ToArrayAsync();
	}

	private IQueryable<AccountTransaction> ApplyFilters(IQueryable<AccountTransaction> query, int accountId, AccountTransactionsFilter filter)
	{
		query = query.Include(a => a.Categoria).Where(a => a.AccountId == accountId);

		if (!string.IsNullOrWhiteSpace(filter.Description))
		{
			query = query.Where(s => s.Description != null && s.Description.Contains(filter.Description));
		}

		if (!string.IsNullOrWhiteSpace(filter.Reference))
		{
			query = query.Where(s => s.Reference != null && s.Reference.Contains(filter.Reference));
		}

		if (!string.IsNullOrWhiteSpace(filter.Payer))
		{
			query = query.Where(s => s.Payer != null && s.Payer.Contains(filter.Payer));
		}

		if (!string.IsNullOrWhiteSpace(filter.Payee))
		{
			query = query.Where(s => s.Payee != null && s.Payee.Contains(filter.Payee));
		}

		if (!string.IsNullOrWhiteSpace(filter.OperationDate))
		{
			query = query.Where(s => DbContext.DateAsString(s.OperationDate).StartsWith(filter.OperationDate));
		}

		if (!string.IsNullOrWhiteSpace(filter.ValueDate))
		{
			query = query.Where(s => DbContext.DateAsString(s.ValueDate).StartsWith(filter.ValueDate));
		}

		if (!string.IsNullOrWhiteSpace(filter.Quantity))
		{
			query = query.Where(s => DbContext.DecimalAsString(s.Quantity).StartsWith(filter.Quantity));
		}

		if (!string.IsNullOrWhiteSpace(filter.Balance))
		{
			query = query.Where(s => DbContext.DecimalAsString(s.Balance).StartsWith(filter.Balance));
		}

		if (!string.IsNullOrWhiteSpace(filter.Categoria))
		{
			query = query.Where(s => s.Categoria != null && s.Categoria.Descripcion.Contains(filter.Categoria));
		}

		return query;
	}


}
