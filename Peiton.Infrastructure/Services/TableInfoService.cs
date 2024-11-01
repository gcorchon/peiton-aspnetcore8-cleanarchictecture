using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Peiton.Contracts.Tablas;
using Peiton.Core;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure;

[Injectable(typeof(IDbTableInfoService))]
public class DbTableInfoService(IDbService dbService) : IDbTableInfoService
{
    public async Task<IEnumerable<ColumnDefinition>> GetColumnDefinitionsAsync(string tableName)
    {
        return await dbService.QueryAsync<ColumnDefinition>(@"SELECT 
            COLUMN_NAME AS ColumnName,
            DATA_TYPE AS SqlType,
            CASE 
                WHEN DATA_TYPE IN ('varchar', 'nvarchar', 'char', 'nchar', 'text', 'ntext') THEN CHARACTER_MAXIMUM_LENGTH
                ELSE NULL
            END AS MaxLength,
            CASE 
                WHEN COLUMN_NAME IN (
                    SELECT COLUMN_NAME
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                    WHERE TABLE_NAME = @tableName 
                    AND OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1
                ) THEN convert(bit, 1)
                ELSE convert(bit, 0)
            END AS IsPrimaryKey,
            CASE 
                WHEN DATA_TYPE IN ('int', 'smallint', 'tinyint', 'bigint', 'decimal', 'numeric', 'float', 'real', 'money', 'smallmoney') THEN 'number'
                WHEN DATA_TYPE IN ('varchar', 'nvarchar', 'char', 'nchar', 'text', 'ntext', 'xml') THEN 'string'
                WHEN DATA_TYPE IN ('bit') THEN 'boolean'
                WHEN DATA_TYPE IN ('datetime', 'smalldatetime', 'date', 'time', 'datetime2', 'datetimeoffset', 'timestamp') THEN 'Date'
                ELSE 'any'
            END AS TypescriptType,
            COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsComputed') AS IsComputed,
            
            (SELECT OBJECT_NAME(FK.referenced_object_id)
            FROM sys.foreign_key_columns AS FK
            WHERE FK.parent_object_id = OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME)
            AND COL_NAME(FK.parent_object_id, FK.parent_column_id) = COLUMN_NAME
            ) AS ForeignKeyReferencedTable,
        
            (SELECT COL_NAME(FK.referenced_object_id, FK.referenced_column_id)
            FROM sys.foreign_key_columns AS FK
            WHERE FK.parent_object_id = OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME)
            AND COL_NAME(FK.parent_object_id, FK.parent_column_id) = COLUMN_NAME
            ) AS ForeignKeyReferencedColumn,
        
            (SELECT TOP 1 C.name
            FROM sys.columns AS C
            INNER JOIN sys.foreign_key_columns AS FK ON FK.referenced_object_id = C.object_id
            WHERE FK.parent_object_id = OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME)
            AND COL_NAME(FK.parent_object_id, FK.parent_column_id) = COLUMN_NAME
            AND C.system_type_id IN (167, 231, 175, 239, 35, 99)  -- ID de tipos de texto en SQL Server
            ORDER BY C.column_id
            ) AS ReferencedTextColumn
        FROM 
            INFORMATION_SCHEMA.COLUMNS
        WHERE 
            TABLE_NAME = @tableName", new { tableName });
    }
}