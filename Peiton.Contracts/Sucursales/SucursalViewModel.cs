namespace Peiton.Contracts.Sucursales;
public class SucursalViewModel
{
    public int Id { get; set; }
    public int EntidadFinancieraId { get; set; }
    public string Numero { get; set; } = null!;
    public string CodigoPostal { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Ciudad { get; set; } = null!;
    public string Provincia { get; set; } = null!;
    public string? Telefono { get; set; }
}
