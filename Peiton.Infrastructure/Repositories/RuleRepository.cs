using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Rules;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRuleRepository))]
	public class RuleRepository: RepositoryBase<Rule>, IRuleRepository
	{
		public RuleRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}

        public Task BorrarReglaAsync(int ruleId)
        {
            return DbContext.Database.ExecuteSqlAsync($@"
                BEGIN TRAN
                    update AccountTransaction set Fk_Rule=null where Fk_Rule={ruleId}
                    delete from [Rule] where Pk_Rule={ruleId}
                    update [Rule] set SortOrder=nuevoOrden
                    from [Rule] inner join (
                    select pk_rule, ROW_NUMBER() over(order by SortOrder) as nuevoOrden
                    from [Rule]
                    ) dv on [Rule].pk_rule = dv.pk_rule
                    where [Rule].SortOrder <> nuevoOrden
                COMMIT TRAN
            ");
        }

        public Task<List<RuleViewModel>> ObtenerRulesAsync()
        {
            return DbContext.Database.SqlQuery<RuleViewModel>(@$"select pk_rule as Id, Description, categoria.descripcion as Categoria, CssClass as BankCssClass 
                                            from [Rule] left Join Categoria on Pk_Categoria=formData.value('(/RuleFormData/Category/Id/text())[1]','int') 
                                            left join EntidadFinanciera on Pk_EntidadFinanciera=formData.value('(/RuleFormData/Bank/text())[1]','int') 
                                            order by SortOrder").ToListAsync();
        }

        public Task ReordenarReglaAsync(int ruleId, int newPosition)
        {
            return DbContext.Database.ExecuteSqlAsync($@"
                begin tran
                declare @currentSortOrder int
                select @currentSortOrder = SortOrder from [Rule] where Pk_Rule={ruleId}
                if @currentSortOrder < {newPosition}
                begin
                    update [Rule] set SortOrder = SortOrder - 1 where SortOrder > @currentSortOrder and SortOrder <= {newPosition}
                end
                if @currentSortOrder > {newPosition}
                begin
                    update [Rule] set SortOrder = SortOrder + 1 where SortOrder < @currentSortOrder and SortOrder >= {newPosition}
                end
                update [Rule] set SortOrder = {newPosition} where Pk_Rule={ruleId}
                commit tran
            ");
        }
    }
}