namespace Peiton.Contracts.Visitas;

public class CrearRegistroEntradaRequest : RegistroEntradaBase
{
    public IEnumerable<Visitante> Visitantes { get; set; } = null!;

}