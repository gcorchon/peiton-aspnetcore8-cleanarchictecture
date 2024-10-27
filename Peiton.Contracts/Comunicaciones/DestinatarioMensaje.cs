namespace Peiton.Contracts.Comunicaciones;

public class DestinatarioMensaje
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int Tipo { get; set; }
}