using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{

    [Injectable(typeof(IUsuarioRepository))]
    public class UsuarioRepository: RepositoryBase<Usuario>, IUsuarioRepository
	{
        
        public UsuarioRepository(PeitonDbContext dbContext) : base(dbContext)
        {
            
        }

        private readonly static string GetPermissionsSql = @"
                select UsuarioPermiso.Fk_Permiso as Value from UsuarioPermiso where Fk_Usuario={0}
                union
                select GrupoPermiso.Fk_Permiso from GrupoUsuario inner join GrupoPermiso 
                on GrupoUsuario.Fk_Grupo = GrupoPermiso.Fk_Grupo
                where GrupoUsuario.Fk_Usuario = {0}";

        private readonly static string HasPermissionSql = @"
                select case when exists(
                        select null from UsuarioPermiso where Fk_Usuario={0} and Fk_Permiso={1}
                        union all
                        select null from GrupoUsuario inner join GrupoPermiso 
                        on GrupoUsuario.Fk_Grupo = GrupoPermiso.Fk_Grupo
                        where GrupoUsuario.Fk_Usuario = {0} and GrupoPermiso.Fk_Permiso={1}) then convert(bit, 1) else convert(bit, 0) end as Value";

        public IEnumerable<int> GetPermissions(int usuarioId)
        {
            var fsf = FormattableStringFactory.Create(GetPermissionsSql, usuarioId);
            return this.DbContext.Database.SqlQuery<int>(fsf);
        }

        public bool HasPermission(int usuarioId, int permisoId)
        {
            var fsf = FormattableStringFactory.Create(HasPermissionSql, usuarioId, permisoId);
            return this.DbContext.Database.SqlQuery<bool>(fsf).SingleOrDefault();
        }

        public Task<IEnumerable<int>> GetPermissionsAsync(int usuarioId)
        {
            return Task.FromResult(this.GetPermissions(usuarioId));
        }

        public Task<bool> HasPermissionAsync(int usuarioId, int permisoId)
        {
            var fsf = FormattableStringFactory.Create(HasPermissionSql, usuarioId, permisoId);
            return this.DbContext.Database.SqlQuery<bool>(fsf).SingleOrDefaultAsync();
        }

        public bool CanViewTutelado(int usuarioId, int tuteladoId)
        {
            return true;
        }
    }
}