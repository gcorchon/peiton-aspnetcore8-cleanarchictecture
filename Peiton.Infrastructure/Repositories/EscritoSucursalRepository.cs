using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEscritoSucursalRepository))]
public class EscritoSucursalRepository(PeitonDbContext dbContext) : RepositoryBase<EscritoSucursal>(dbContext), IEscritoSucursalRepository
{
    public Task<IEnumerable<EscritoSucursalListItem>> ObtenerSucursalesAsync(int tuteladoId)
    {
        return DbContext.Database.GetDbConnection().QueryAsync<EscritoSucursalListItem>(@"select 
                                Pk_EntidadFinanciera as EntidadFinancieraId,
                                EntidadFinanciera.Descripcion as EntidadFinanciera,
                                EntidadFinanciera.CssClass,
                                o.Branch as Numero,
                                Sucursal.CodigoPostal,
                                Sucursal.Direccion,
                                Sucursal.Ciudad,
                                Sucursal.Provincia,
                                InformadaTutela, SolicitudBloqueo, PeticionClaves, RecepcionClaves, PrimeraSolicitud, SegundaSolicitud
                        from dbo.ObtenerOficinasTutelado(@tuteladoId) o inner join EntidadFinanciera
                        on Pk_EntidadFinanciera = o.Fk_EntidadFinanciera
                        left join Sucursal on Sucursal.Numero =  o.Branch and Sucursal.Fk_EntidadFinanciera = o.Fk_EntidadFinanciera
                        left join EscritoSucursal ES on ES.Fk_EntidadFinanciera = o.Fk_EntidadFinanciera 
                                and ES.Numero=o.Branch and ES.Fk_Tutelado = @tuteladoId", new { tuteladoId });
    }
}
