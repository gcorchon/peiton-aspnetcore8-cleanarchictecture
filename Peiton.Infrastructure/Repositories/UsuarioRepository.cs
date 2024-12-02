using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Usuarios;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IUsuarioRepository))]
public class UsuarioRepository(PeitonDbContext dbContext, IIdentityService identityService) : RepositoryBase<Usuario>(dbContext), IUsuarioRepository
{
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

    public Task<bool> HasPermissionAsync(int permisoId)
    {
        return this.HasPermissionAsync(identityService.GetUserId(), permisoId);
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

    public bool CanViewTutelado(int tuteladoId)
    {
        return this.CanViewTutelado(identityService.GetUserId(), tuteladoId);
    }

    public Task<UsuarioTipo[]> ObtenerUsuariosGruposAsync(string q, int v)
    {
        var search = "%" + q + "%";

        return this.DbContext.Database.SqlQuery<UsuarioTipo>(@$"select * from 
                                            (
                                                select Pk_Usuario as Id, NombreCompleto as Nombre, 1 as Tipo
                                                from Usuario where borrado=0
                                                union all 
                                                select Pk_Grupo as Id, Descripcion as Nombre, 2 as Tipo
                                                from Grupo
                                            ) dv where Nombre like {search} order by case when Nombre={q} then 1 when Nombre like {q + "%"} then 2 else 3 end, Nombre
                                            offset 0 rows fetch next {v} rows only
                                            ").ToArrayAsync();
    }

    public Task<Usuario?> ObtenerUsuarioAsync(string nombre)
    {
        return DbSet.FirstOrDefaultAsync(u => u.NombreCompleto == nombre);
    }

    public Task<Usuario[]> ObtenerUsuariosConPermisoAsync(int[] userIds, int permisoId)
    {
        return DbSet.Where(u => userIds.Contains(u.Id) && (u.Permisos.Any(p => p.Id == permisoId) || u.Grupos.Any(g => g.Permisos.Any(p2 => p2.Id == permisoId)))).ToArrayAsync();
    }

    public Task<Usuario[]> ObtenerUsuariosConGruposAsync()
    {
        return DbSet.Include(u => u.Grupos.OrderBy(g => g.Descripcion))
                    .Where(u => !u.Borrado)
                    .OrderBy(u => u.NombreCompleto)
                    .AsNoTracking()
                    .ToArrayAsync();
    }

    public Task<int> ContarUsuariosBloqueadosAsync(UsuariosBloqueadosFilter filter)
    {
        return ApplyFilters(DbSet.Where(u => u.Bloqueado), filter).CountAsync();
    }

    public Task<Usuario[]> ObtenerUsuariosBloqueadosAsync(int page, int total, UsuariosBloqueadosFilter filter)
    {
        return ApplyFilters(DbSet.Where(u => u.Bloqueado), filter)
            .OrderBy(s => s.Id)
            .Skip((page - 1) * total)
            .Take(total)
            .AsNoTracking()
            .ToArrayAsync();
    }

    private IQueryable<Usuario> ApplyFilters(IQueryable<Usuario> query, UsuariosBloqueadosFilter filter)
    {
        if (filter == null) return query;
        if (!string.IsNullOrWhiteSpace(filter.Username))
        {
            query = query.Where(s => s.Username.Contains(filter.Username));
        }

        if (!string.IsNullOrWhiteSpace(filter.Email))
        {
            query = query.Where(s => s.Email.Contains(filter.Email));
        }

        if (!string.IsNullOrWhiteSpace(filter.NombreCompleto))
        {
            query = query.Where(s => s.NombreCompleto.Contains(filter.NombreCompleto));
        }

        return query;
    }

    public async Task<Usuario> GetMeAsync()
    {
        var usuario = await this.GetByIdAsync(identityService.GetUserId());
        if (usuario != null) return usuario;
        throw new Exception("El usuario no está autenticado");
    }
}
