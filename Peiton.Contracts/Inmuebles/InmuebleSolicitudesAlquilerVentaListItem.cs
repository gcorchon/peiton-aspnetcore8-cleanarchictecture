namespace Peiton.Contracts.Inmuebles;
public class InmuebleSolicitudAlquilerVentaListItem
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string? Tipo { get; set; } = null!;

    /// <summary>
    /// 1 - Pendiente, 2 - En trámite, 3 - Finalizado
    /// </summary>
    public string? Estado { get; set; }
}
