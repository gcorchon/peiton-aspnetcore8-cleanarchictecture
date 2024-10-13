namespace Peiton.Contracts.Inmuebles;
public class InmuebleSolicitudesAlquilerVentaFilter
{
    public string? Id { get; set; }
    public string? Tutelado { get; set; }
    public string? Direccion { get; set; }


    /// <summary>
    /// Alquiler / Venta
    /// </summary>
    public string? Tipo { get; set; }

    /// <summary>
    /// 1 - Pendiente, 2 - En trámite, 3 - Finalizado
    /// </summary>
    public int? Estado { get; set; }
}
