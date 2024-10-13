namespace Peiton.Core.Entities;
public class GestorAdministrativo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Domicilio { get; set; } = null!;
    public string Localidad { get; set; } = null!;
    public string CodigoPostal { get; set; } = null!;
    public string Provincia { get; set; } = null!;
    public string Telefono1 { get; set; } = null!;
    public string Telefono2 { get; set; } = null!;
    public string Telefono3 { get; set; } = null!;
    public string Email { get; set; } = null!;
}
