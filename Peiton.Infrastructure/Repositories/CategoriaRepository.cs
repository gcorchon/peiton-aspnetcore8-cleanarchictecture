using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaRepository))]
public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
{
	public CategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task BorrarCategoriaAsync(int id)
	{
		return this.DbContext.Database.ExecuteSqlAsync(@$"declare @Categoriatree table (Pk_Categoria int, Descripcion nvarchar(255), Fk_CategoriaPadre int, Level int, BreadCrumb nvarchar(max));
	
	                        with data  (Pk_Categoria, Descripcion, Fk_CategoriaPadre, Level, BreadCrumb) as
	                        (
		                        select Pk_Categoria, Descripcion, Fk_CategoriaPadre, 0 as Level, Convert(nvarchar(max),Descripcion) as BreadCrumb
		                        from Categoria
		                        where Pk_Categoria={id}
		                        union all
		                        select c.Pk_Categoria, c.Descripcion, c.Fk_CategoriaPadre, Level+1 as Level, Convert(nvarchar(max), data.BreadCrumb + ' > ' + c.Descripcion) as BreadCrumb
		                        from Categoria c inner join Data
		                        on c.Fk_CategoriaPadre=data.Pk_Categoria where c.Fk_CategoriaPadre is not null
	                        )

	                        insert into @Categoriatree (Pk_Categoria, Descripcion, Fk_CategoriaPadre, Level, BreadCrumb)
	                        select Pk_Categoria, Descripcion, Fk_CategoriaPadre, Level, BreadCrumb from data order by BreadCrumb

	                        declare @Pk_Categoria_To_Delete int

	                        declare c cursor for select Pk_Categoria from @Categoriatree order by [Level] desc
	                        open c
	                        fetch next from c into @Pk_Categoria_To_Delete
	                        if @@fetch_status = 0
	                        begin
		                        declare @ok bit
		                        set @ok = 1
		                        begin tran
		                        while @@fetch_status = 0 and @ok = 1
		                        begin
                                    update AccountTransaction set Fk_Rule=null 
                                    from AccountTransaction inner join [Rule] on Pk_Rule=Fk_Rule
                                    where FormData.value('(/RuleFormData/Category/Id/text())[1]', 'int') = @Pk_Categoria_To_Delete

                                    delete from [Rule] where FormData.value('(/RuleFormData/Category/Id/text())[1]', 'int') = @Pk_Categoria_To_Delete

                                    update AccountTransaction set Fk_Categoria=null where Fk_Categoria = @Pk_Categoria_To_Delete
			                        
                                    delete from Categoria where Pk_Categoria=@Pk_Categoria_To_Delete
			                        
                                    if @@error <> 0
			                        begin
				                        set @ok = 0
			                        end
			                        fetch next from c into @Pk_Categoria_To_Delete
		                        end
		                        if @ok = 1 
		                        begin
			                        commit tran
		                        end
		                        else
		                        begin
			                        rollback tran
		                        end
	                        end
	                        close c
	                        deallocate c");
	}
}
