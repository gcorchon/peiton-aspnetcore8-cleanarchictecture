namespace Peiton.Contracts.Autorizaciones;

public class AutorizacionListItem
{
    public int Id {get; set; }
    public string Descripcion { get; set; } = null!;
    public bool Aprobada { get; set; }    
}