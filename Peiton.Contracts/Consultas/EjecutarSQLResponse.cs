namespace Peiton.Contracts.Consultas;

public class EjecutarSQLResponse
{
    public IEnumerable<Column> Columns { get; set; } = new List<Column>();
    public IEnumerable<object[]> Rows { get; set; } = [];
}