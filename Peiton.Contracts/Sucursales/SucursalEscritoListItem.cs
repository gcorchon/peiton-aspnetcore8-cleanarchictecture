namespace Peiton.Contracts.Sucursales;

public class SucursalEscritoListItem
{
        public int Id { get; set; }
        public string EntidadFinanciera { get; set; } = null!;
        public string? CssClass { get; set; }
        public string Numero { get; set; } = null!;
        public string CodigoPostal { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string? Telefono { get; set; }
}