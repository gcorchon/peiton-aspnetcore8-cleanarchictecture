namespace Peiton.Contracts.Inmuebles;
public class InmuebleSolicitudAlquilerVentaViewModel
{
    public int Id { get; set; }

    /// <summary>
    /// Persona de contacto
    /// </summary>
    public string? Nombre { get; set; }

    /// <summary>
    /// Teléfono de contacto
    /// </summary>
    public string? Contacto { get; set; }
    public string? Comentarios { get; set; }
    public string? ObservacionesDepartamentoInmuebles { get; set; }
    public int Estado { get; set; }
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; } = null!;
    public string? Observaciones { get; set; }

    public InmuebleSolicitudAlquilerVentaInfo Inmueble { get; set; } = null!;
    public string? Ocupacion { get; set; }
    public string Trabajador { get; set; } = null!;
}