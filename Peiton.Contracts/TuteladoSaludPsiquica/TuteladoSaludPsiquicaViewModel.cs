namespace Peiton.Contracts.TuteladoSaludPsiquica;

public class TuteladoSaludPsiquicaViewModel
{
    public int Orden { get; set; }
    public int? SituacionSaludId { get; set; }
    public int? ConcienciaEnfermedadId { get; set; }
    public int? AdhesionTratamientoId { get; set; }
    public bool? SeguimientoTratamiento { get; set; }
    public int? AutonomiaTratamientoId { get; set; }
    public string? Patologia { get; set; }
}