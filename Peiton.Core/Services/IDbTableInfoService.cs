using Peiton.Contracts.Tablas;

namespace Peiton.Core.Services;

public interface IDbTableInfoService
{
    Task<IEnumerable<ColumnDefinition>> GetColumnDefinitionsAsync(string tableName);
}