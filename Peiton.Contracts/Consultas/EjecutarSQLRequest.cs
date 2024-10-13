namespace Peiton.Contracts.Consultas;

public class EjecutarSQLRequest
{
    public string Query { get; set; } = null!;
    public IEnumerable<ParametroConsulta> Parameters { get; set; } = new List<ParametroConsulta>();
}

