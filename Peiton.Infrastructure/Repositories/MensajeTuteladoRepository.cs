using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.MensajesTuAppoyo;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMensajeTuteladoRepository))]
public class MensajeTuteladoRepository(PeitonDbContext dbContext, IIdentityService identityService) : RepositoryBase<MensajeTutelado>(dbContext), IMensajeTuteladoRepository
{
	public Task<MensajeTuAppoyoListItem[]> ObtenerMensajesRecibidosAsync(int page, int total, MensajesTuAppoyoFilter filter)
	{
		var usuarioId = identityService.GetUserId();

		var query = this.DbContext.Database.SqlQuery<MensajeTuAppoyoListItem>($@"
                    select Pk_MensajeTutelado as Id, Asunto, Fecha, coalesce(c.value('@leido', 'bit'), convert(bit, 0)) as Leido, Tutelado.Pk_Tutelado as TuteladoId, Tutelado.NombreCompleto as Remitente, Tutelado.Foto as Avatar 
                    from MensajeTutelado
                    cross apply MensajeTutelado.Info.nodes('/datos/destinatarios/usuario') as t1(c)
                    cross apply MensajeTutelado.Info.nodes('/datos/remitente[@tipo=""tutelado""]') as t2(r)
                    inner join Tutelado on Tutelado.Pk_Tutelado = r.value('@id', 'int')
                    where c.value('@id', 'int') = {usuarioId} and c.value('@borrado', 'bit') is null");

		return ApplyFilters(query, filter)
					.OrderByDescending(m => m.Id)
					.Skip((page - 1) * total)
					.Take(total)
					.ToArrayAsync();
	}

	public Task<int> ContarMensajesRecibidosAsync(MensajesTuAppoyoFilter filter)
	{
		var usuarioId = identityService.GetUserId();

		var query = this.DbContext.Database.SqlQuery<MensajeTuAppoyoListItem>($@"
                    select Pk_MensajeTutelado as Id, Asunto, Fecha, coalesce(c.value('@leido', 'bit'), convert(bit, 0)) as Leido, Tutelado.Pk_Tutelado as TuteladoId, Tutelado.NombreCompleto as Remitente, Tutelado.Foto as Avatar 
                    from MensajeTutelado
                    cross apply MensajeTutelado.Info.nodes('/datos/destinatarios/usuario') as t1(c)
                    cross apply MensajeTutelado.Info.nodes('/datos/remitente[@tipo=""tutelado""]') as t2(r)
                    inner join Tutelado on Tutelado.Pk_Tutelado = r.value('@id', 'int')
                    where c.value('@id', 'int') = {usuarioId} and c.value('@borrado', 'bit') is null");

		return ApplyFilters(query, filter).CountAsync();
	}

	private IQueryable<MensajeTuAppoyoListItem> ApplyFilters(IQueryable<MensajeTuAppoyoListItem> query, MensajesTuAppoyoFilter filter)
	{
		if (filter == null) return query;

		if (filter.Leido.HasValue)
		{
			query = query.Where(s => s.Leido == filter.Leido);
		}

		if (!string.IsNullOrWhiteSpace(filter.Remitente))
		{
			query = query.Where(s => s.Remitente.Contains(filter.Remitente));
		}

		if (!string.IsNullOrWhiteSpace(filter.Asunto))
		{
			query = query.Where(s => s.Asunto.Contains(filter.Asunto));
		}

		if (filter.Fecha.HasValue)
		{
			query = query.Where(s => s.Fecha.Date == filter.Fecha.Value.Date);
		}

		return query;
	}



	public Task<MensajeTuAppoyoEnviadoListItem[]> ObtenerMensajesEnviadosAsync(int page, int total, MensajesTuAppoyoEnviadosFilter filter)
	{

		var usuarioId = identityService.GetUserId();

		var query = this.DbContext.Database.SqlQuery<MensajeTuAppoyoEnviadoListItem>($@"
                    select Pk_MensajeTutelado as Id, Asunto, Fecha, Tutelado.NombreCompleto as Destinatario, Tutelado.Foto as Avatar 
                    from MensajeTutelado
                    cross apply MensajeTutelado.Info.nodes('/datos/destinatarios/tutelado') as t1(c)
                    cross apply MensajeTutelado.Info.nodes('/datos/remitente[@tipo=""usuario""]') as t2(r)
                    inner join Tutelado on Tutelado.Pk_Tutelado = c.value('@id', 'int')
                    where r.value('@id', 'int') = {usuarioId} and r.value('@borrado', 'bit') is null");


		return ApplyFilters(query, filter)
					.OrderByDescending(m => m.Id)
					.Skip((page - 1) * total)
					.Take(total)
					.ToArrayAsync();
	}

	public Task<int> ContarMensajesEnviadosAsync(MensajesTuAppoyoEnviadosFilter filter)
	{
		var usuarioId = identityService.GetUserId();

		var query = this.DbContext.Database.SqlQuery<MensajeTuAppoyoEnviadoListItem>($@"
                    select Pk_MensajeTutelado as Id, Asunto, Fecha, Tutelado.NombreCompleto as Destinatario, Tutelado.Foto as Avatar 
                    from MensajeTutelado
                    cross apply MensajeTutelado.Info.nodes('/datos/destinatarios/tutelado') as t1(c)
                    cross apply MensajeTutelado.Info.nodes('/datos/remitente[@tipo=""usuario""]') as t2(r)
                    inner join Tutelado on Tutelado.Pk_Tutelado = c.value('@id', 'int')
                    where r.value('@id', 'int') = {usuarioId} and r.value('@borrado', 'bit') is null");

		return ApplyFilters(query, filter).CountAsync();
	}


	private IQueryable<MensajeTuAppoyoEnviadoListItem> ApplyFilters(IQueryable<MensajeTuAppoyoEnviadoListItem> query, MensajesTuAppoyoEnviadosFilter filter)
	{
		if (filter == null) return query;

		if (!string.IsNullOrWhiteSpace(filter.Destinatario))
		{
			query = query.Where(s => s.Destinatario.Contains(filter.Destinatario));
		}

		if (!string.IsNullOrWhiteSpace(filter.Asunto))
		{
			query = query.Where(s => s.Asunto.Contains(filter.Asunto));
		}

		if (filter.Fecha.HasValue)
		{
			query = query.Where(s => s.Fecha.Date == filter.Fecha.Value.Date);
		}

		return query;
	}


	public Task<int> ContarMensajesSinLeerAsync()
	{
		return DbContext.Database.GetDbConnection().ExecuteScalarAsync<int>(@"select count(*)
                    from MensajeTutelado
                    cross apply Info.nodes('/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"") and not(@borrado) and not(@leido)]') as t(c)", new { usuarioId = identityService.GetUserId() });
	}


	public async Task MarcarComoLeidoAsync(int id)
	{
		var sql = @"update MensajeTutelado set Info.modify('insert  
					if (/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")]/@leido)  
					then()
					else (attribute leido { ""1""})  
					as first into(/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")])[1]')
					where Pk_MensajeTutelado = @id";

		var usuarioId = identityService.GetUserId();
		await this.DbContext.Database.GetDbConnection().ExecuteAsync(sql, new { id, usuarioId });
	}

	public async Task MarcarRecibidoComoBorradoAsync(int id)
	{
		var sql = @"update MensajeTutelado set Info.modify('insert  
					if (/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")]/@borrado)  
					then()
					else (attribute borrado {""1""})  
					as first into(/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")])[1]')
					where Pk_MensajeTutelado = @id";

		var usuarioId = identityService.GetUserId();
		await this.DbContext.Database.GetDbConnection().ExecuteAsync(sql, new { id, usuarioId });

	}

	public async Task MarcarRecibidosComoBorradoAsync(int[] ids)
	{
		var sql = @"update MensajeTutelado set Info.modify('insert  
					if (/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")]/@borrado)  
					then()
					else (attribute borrado {""1""})  
					as first into(/datos/destinatarios/usuario[@id=sql:variable(""@usuarioId"")])[1]')
					where Pk_MensajeTutelado in (" + string.Join(",", ids) + ")";

		var usuarioId = identityService.GetUserId();
		await this.DbContext.Database.GetDbConnection().ExecuteAsync(sql, new { usuarioId });
	}

	public async Task MarcarEnviadoComoBorradoAsync(int id)
	{
		var sql = @"update MensajeTutelado set Info.modify('insert  
                        if (/datos/remitente[@id=sql:variable(""@usuarioId"") and @tipo=""usuario""]/@borrado)  
                        then()
                        else (attribute borrado {""1""})  
                        as first into(/datos/remitente[@id=sql:variable(""@usuarioId"") and @tipo=""usuario""])[1]')
                        where Pk_MensajeTutelado = @id";

		var usuarioId = identityService.GetUserId();
		await this.DbContext.Database.GetDbConnection().ExecuteAsync(sql, new { id, usuarioId });
	}
}
