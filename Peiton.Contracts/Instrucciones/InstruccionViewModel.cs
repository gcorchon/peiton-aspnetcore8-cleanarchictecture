namespace Peiton.Contracts.Instrucciones;

public class InstruccionViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public DateTime Fecha { get; set; }
}