using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Capitulo;
using System.Runtime.CompilerServices;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICapituloRepository))]
	public class CapituloRepository: RepositoryBase<Capitulo>, ICapituloRepository
	{
        
        public CapituloRepository(PeitonDbContext dbContext) : base(dbContext)
        {
            
        }

        public IAsyncEnumerable<CapituloViewModel> ObtenerCapitulosAsync(CapituloFilter filter)
        {
            var conditions = new List<string>();
            var paramValues = new List<object>(){ filter.Ano };

            
            if (!string.IsNullOrWhiteSpace(filter.Tipo))
            {
                conditions.Add("tipo = {" + paramValues.Count + "}");
                paramValues.Add(filter.Tipo);
            }

            if (!string.IsNullOrWhiteSpace(filter.Capitulo))
            {
                conditions.Add("capitulo like {" + paramValues.Count + "}");
                paramValues.Add(filter.Capitulo + "%");
            }

            if (!string.IsNullOrEmpty(filter.Partida))
            {
                conditions.Add("(Pk_Partida is not null and Partida like {" + paramValues.Count + "})");
                paramValues.Add(filter.Partida + "%");
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                conditions.Add("Descripcion like {" + paramValues.Count + "}");
                paramValues.Add("%" + filter.Descripcion + "%");
            }

            if (!string.IsNullOrEmpty(filter.SaldoInicial))
            {
                conditions.Add("replace(convert(varchar, SaldoInicial, 2),'.',',') like {" + paramValues.Count + "}");
                paramValues.Add(filter.SaldoInicial.Replace('.', ',') + "%");
            }

            var whereCondition = "";
            if (conditions.Any())
            {
                whereCondition = "where " + string.Join(" and ", conditions.ToArray());
            }

            var sql = @"select Tipo, Pk_Capitulo as CapituloId, Capitulo, Pk_Partida as PartidaId, Partida, Descripcion, SaldoInicial 
                        from dbo.fnCapitulosYPartidas({0}) "  + whereCondition + " order by Tipo, Capitulo, Partida"; 

            var fstr = FormattableStringFactory.Create(sql, paramValues.ToArray());
                                    
            return this.DbContext.Database.SqlQuery<CapituloViewModel>(fstr).AsAsyncEnumerable();
                                
        }

        /*public Task<List<Capitulo>> ObtenerCapitulosAsync(CapituloFilter filter)
        {
			var query = this.DbSet.Where(c => c.Ano ==  filter.Ano);

            if (!string.IsNullOrWhiteSpace(filter.Partida) || filter.SaldoInicial.HasValue)
            {
                //query = query.Include(c => c.Partidas.Where(p => p.Numero == filter.Partida && p.SaldoInicial >= filter.SaldoInicial.Value));
                
                var parameter = Expression.Parameter(typeof(Capitulo), "c");
                var partidasProperty = Expression.Property(parameter, "Partidas");
                var partidaParameter = Expression.Parameter(typeof(Partida), "p");

                var conditions = new List<Expression>();
                if (!string.IsNullOrWhiteSpace(filter.Partida))
                {
                    var numeroProperty = Expression.Property(partidaParameter, "Numero");
                    var filterPartida = Expression.Constant(filter.Partida);
                    var condition1 = Expression.Equal(numeroProperty, filterPartida);
                    conditions.Add(condition1);
                }

                if (filter.SaldoInicial.HasValue)
                {
                    var saldoInicialProperty = Expression.Property(partidaParameter, "SaldoInicial");
                    var filterSaldoInicial = Expression.Constant(filter.SaldoInicial.Value, typeof(decimal));
                    var condition2 = Expression.GreaterThanOrEqual(saldoInicialProperty, filterSaldoInicial);
                    conditions.Add(condition2);
                }

                if (conditions.Any())
                {
                    var combinedCondition = conditions[0];
                    for(var i=1; i<conditions.Count; i++)
                    {
                        combinedCondition = Expression.AndAlso(combinedCondition, conditions[i]);
                    }

                    var lambdaFilter = Expression.Lambda<Func<Partida, bool>>(combinedCondition, partidaParameter);

                    // Convertir la colecci�n a IQueryable
                    var asQueryableCall = Expression.Call(
                        typeof(Queryable),
                        "AsQueryable",
                        new Type[] { typeof(Partida) },
                        partidasProperty
                    );

                    var whereCall = Expression.Call(
                        typeof(Queryable),
                        "Where",
                        new Type[] { typeof(Partida) },
                        asQueryableCall,
                        lambdaFilter
                    );

                    var lambdaInclude = Expression.Lambda<Func<Capitulo, IEnumerable<Partida>>>(whereCall, parameter);
                    query = query.Include(lambdaInclude);
                }  
            }
			else
			{
				query = query.Include(c => c.Partidas);
			}

            if (!string.IsNullOrWhiteSpace(filter.Tipo))
			{
				query = query.Where(c => c.Tipo == filter.Tipo);
			}
			
			if(!string.IsNullOrWhiteSpace(filter.Capitulo))
			{
				query = query.Where(c => c.Numero == filter.Capitulo);
			}

			if(!string.IsNullOrWhiteSpace(filter.Descripcion))
			{
				query = query.Where(c => c.Descripcion.Contains(filter.Descripcion));
			}

            return query
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.Numero)
                .ToListAsync();			

        }*/


    }
}