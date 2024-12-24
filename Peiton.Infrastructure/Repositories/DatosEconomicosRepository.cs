using Dapper;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Account;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosEconomicosRepository))]
public class DatosEconomicosRepository(PeitonDbContext dbContext) : RepositoryBase<DatosEconomicos>(dbContext), IDatosEconomicosRepository
{
    public async Task<IEnumerable<ProductoBancarioConSaldoListItem>> ObtenerProductosRendicionAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta)
    {
        string sql = @"            
        SELECT [Pk_Account] as Id,
                Convert(bit, 0) as  'Manual',
                Credencial.[Fk_EntidadFinanciera] as [EntidadFinancieraId],
                EntidadFinanciera.Descripcion as [EntidadFinancieraDescripcion],
                [TipoProducto].Pk_TipoProducto as [TipoProductoId],
                [TipoProducto].Descripcion as [TipoProductoDescripcion],
                Iban as Identificacion,
                [Account].[WebAlias] as Nombre, 
                [Account].[Titularidad], 
                [SaldoReal].Balance as [Saldo],
                [SaldoReal].Fecha as [FechaSaldo],
                [Account].[Baja],
                [Account].[FechaBaja],
                [Account].[Fecha],
                [Account].[Observaciones]
        FROM [Account] 
        INNER JOIN Credencial on Pk_Credencial = Fk_Credencial
        INNER JOIN EntidadFinanciera on Pk_EntidadFinanciera = Fk_EntidadFinanciera
        INNER JOIN dbo.ObtenerSaldosAccounts(@TuteladoId, @fechaSaldo) SaldoReal on [Account].Pk_Account=SaldoReal.Fk_Account
        CROSS JOIN TipoProducto 
        where Fk_Tutelado=@TuteladoId and Pk_TipoProducto=1 and Account.Fecha<@fechaSaldo and (Account.FechaBaja is null or (Account.FechaBaja >= @fechaDesde))
        UNION ALL
        SELECT [Pk_Fund] as Id,
                Convert(bit, 0) as  'Manual',
                Credencial.[Fk_EntidadFinanciera] as [EntidadFinancieraId],
                EntidadFinanciera.Descripcion as [EntidadFinancieraDescripcion],
                [TipoProducto].Pk_TipoProducto as [TipoProductoId],
                [TipoProducto].Descripcion as [TipoProductoDescripcion],
                [AccountNumber] as Identificacion,
                [Fund].[WebAlias] as Nombre, 
                [Fund].[Titularidad], 
                [SaldoReal].[Saldo],
                [SaldoReal].[FechaSaldo],
                [Fund].[Baja],
                [Fund].[FechaBaja],
                [Fund].[Fecha],
                [Fund].[Observaciones]
        FROM [Fund] 
        INNER JOIN Credencial on Pk_Credencial = Fk_Credencial
        INNER JOIN EntidadFinanciera on Pk_EntidadFinanciera = Fk_EntidadFinanciera
        INNER JOIN dbo.ObtenerSaldosFunds(@TuteladoId, @fechaSaldo) SaldoReal on [Fund].Pk_Fund=SaldoReal.Fk_Fund
        CROSS JOIN TipoProducto 
        WHERE Fk_Tutelado=@TuteladoId and Pk_TipoProducto=2  and  (Fund.FechaBaja is null or Fund.FechaBaja > @fechaDesde)
        UNION ALL
        SELECT [Pk_Deposit] as Id,
                Convert(bit, 0) as  'Manual',
                Credencial.[Fk_EntidadFinanciera] as [EntidadFinancieraId],
                EntidadFinanciera.Descripcion as [EntidadFinancieraDescripcion],
                [TipoProducto].Pk_TipoProducto as [TipoProductoId],
                [TipoProducto].Descripcion as [TipoProductoDescripcion],
                [AccountNumber] as Identificacion,
                [Deposit].[WebAlias] as Nombre, 
                [Deposit].[Titularidad], 
                [SaldoReal].[Saldo], 
                [SaldoReal].[FechaSaldo],
                [Deposit].[Baja],
                [Deposit].[FechaBaja],
                [Deposit].[Fecha],
                [Deposit].[Observaciones]
        FROM [Deposit] 
        INNER JOIN Credencial on Pk_Credencial = Fk_Credencial
        INNER JOIN EntidadFinanciera on Pk_EntidadFinanciera = Fk_EntidadFinanciera
        INNER JOIN dbo.ObtenerSaldosDeposits(@TuteladoId, @fechaSaldo) SaldoReal on [Deposit].Pk_Deposit=SaldoReal.Fk_Deposit
        CROSS JOIN TipoProducto 
        WHERE Fk_Tutelado=@TuteladoId and Pk_TipoProducto=3 and (Deposit.FechaBaja is null or Deposit.FechaBaja >= @fechaDesde)
        UNION ALL
        SELECT [Pk_Share] as Id,
                Convert(bit, 0) as  'Manual',
                Credencial.[Fk_EntidadFinanciera] as [EntidadFinancieraId],
                EntidadFinanciera.Descripcion as [EntidadFinancieraDescripcion],
                [TipoProducto].Pk_TipoProducto as [TipoProductoId],
                [TipoProducto].Descripcion as [TipoProductoDescripcion],
                [AccountNumber] as Identificacion,
                [Share].[WebAlias] as Nombre, 
                [Share].[Titularidad], 
                [SaldoReal].[Saldo], 
                [SaldoReal].[FechaSaldo], 
                [Share].[Baja], 
                [Share].[FechaBaja], 
                [Share].[Fecha], 
                [Share].[Observaciones]
        FROM [Share] 
        INNER JOIN Credencial on Pk_Credencial = Fk_Credencial
        INNER JOIN EntidadFinanciera on Pk_EntidadFinanciera = Fk_EntidadFinanciera
        INNER JOIN dbo.ObtenerSaldosShares(@TuteladoId, @fechaSaldo) SaldoReal on [Share].Pk_Share=SaldoReal.Fk_Share
        CROSS JOIN TipoProducto 
        WHERE Fk_Tutelado=@TuteladoId and Pk_TipoProducto=4 and (Share.FechaBaja is null or Share.FechaBaja >= @fechaDesde)";

        return await DbContext.Database.GetDbConnection().QueryAsync<ProductoBancarioConSaldoListItem>(sql, new { FechaDesde = fechaDesde, FechaSaldo = fechaHasta, TuteladoId = tuteladoId });
    }


    public async Task<IEnumerable<JustificacionIngresosYGastos>> ObtenerJustificaionIngresosYGastosAsync(int tuteladoId, DateTime fechaDesde, DateTime fechaHasta)
    {
        string sql = @"select * from (
                  SELECT  Categoria.Descripcion as Categoria, Categoria.Fk_TipoCategoria as TipoCategoriaId, isnull(SUM(AccountTransaction.Quantity),0) AS Total, Categoria.Pk_Categoria as CategoriaId
                  FROM AccountTransaction INNER JOIN
                              Categoria ON AccountTransaction.Fk_Categoria = Categoria.Pk_Categoria INNER JOIN
                              Account ON AccountTransaction.Fk_Account = Account.Pk_Account INNER JOIN
                              Credencial ON Account.Fk_Credencial = Credencial.Pk_Credencial
                    WHERE AccountTransaction.OperationDate >= @FechaDesde 
			              AND AccountTransaction.OperationDate <= @FechaHasta 
                          AND Credencial.Fk_Tutelado=@TuteladoId
			              AND Categoria.Fk_TipoCategoria in (1,2)
                          AND (Account.FechaBaja is null or Account.FechaBaja> @fechaDesde) 
                    GROUP BY Categoria.Pk_Categoria, Categoria.Fk_TipoCategoria, Categoria.Descripcion
                    UNION ALL
                    SELECT  'Otros gastos' as Categoria, 2 as TipoCategoriaId, isnull(SUM(AccountTransaction.Quantity),0) AS Total, -1 as CategoriaId
                    FROM AccountTransaction INNER JOIN
                         Account ON AccountTransaction.Fk_Account = Account.Pk_Account INNER JOIN 
                         Credencial ON Account.Fk_Credencial = Credencial.Pk_Credencial
                         WHERE AccountTransaction.Quantity < 0 
                               AND Credencial.Fk_Tutelado=@TuteladoId 
                               AND AccountTransaction.OperationDate >= @FechaDesde 
				               AND AccountTransaction.OperationDate <= @FechaHasta
                               AND Fk_Categoria is null 
                               AND (Account.FechaBaja is null or Account.FechaBaja> @fechaDesde)
                    UNION ALL
                    SELECT 'Otros ingresos' as Categoria, 1 as TipoCategoriaId, isnull(SUM(AccountTransaction.Quantity),0) AS Total, -2 as CategoriaId
                    FROM AccountTransaction INNER JOIN
                         Account ON AccountTransaction.Fk_Account = Account.Pk_Account INNER JOIN 
                         Credencial ON Account.Fk_Credencial = Credencial.Pk_Credencial
                         WHERE AccountTransaction.Quantity > 0 		   
                               AND Credencial.Fk_Tutelado=@TuteladoId 
                               AND AccountTransaction.OperationDate >= @FechaDesde 
				               and AccountTransaction.OperationDate <= @FechaHasta
				               AND Fk_Categoria is null
                               AND (Account.FechaBaja is null  or Account.FechaBaja> @fechaDesde)
               ) dv where Total <> 0";

        return await DbContext.Database.GetDbConnection().QueryAsync<JustificacionIngresosYGastos>(sql, new { FechaDesde = fechaDesde, FechaHasta = fechaHasta, TuteladoId = tuteladoId });
    }
}
