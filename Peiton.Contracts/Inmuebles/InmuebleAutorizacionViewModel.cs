namespace Peiton.Contracts.Inmuebles;
public class InmuebleAutorizacionViewModel
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;
    public string Dni { get; set; } = null!;
    public string DireccionCompleta { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string Motivo { get; set; } = null!;
    public string Trabajador { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string Observaciones { get; set; } = null!;
    public bool Autorizado { get; set; }
    public bool Presentado { get; set; }
    public bool Firme { get; set; }
    public DateTime? FechaAutorizado { get; set; }
    public DateTime? FechaPresentado { get; set; }
    public DateTime? FechaFirme { get; set; }
    public DateTime Fecha { get; set; }

    public bool Archivo { get; set; }
}
