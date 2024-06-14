namespace Peiton.Core.Entities;

public class VwCajaAMTA
{
    public int Id { get; set; }
    public int? TuteladoId { get; set; }
    public DateTime Fecha { get; set; }
    public int Tipo { get; set; }
    public string Concepto { get; set; } = "";
    public string? Persona { get; set; }
    public decimal Importe { get; set; }
    public decimal Saldo { get; set; }
    public int? CajaId { get; set; }

    public virtual Tutelado? Tutelado { get; set; }
    public virtual Caja? Caja { get; set; }
}