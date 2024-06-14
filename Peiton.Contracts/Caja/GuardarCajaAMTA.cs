namespace Peiton.Contracts.Caja;

public class GuardarCajaAMTA
{
    public int Tipo { get; set; }
    public string Concepto { get; set; } = "";
    public string? Persona { get; set; }
    public int? TuteladoId { get; set; }
    public decimal Importe { get; set; }
}