namespace Peiton.Contracts.Seguimientos;

public class SeguimientoListItem
{
    public int Id { get; set; }
    public string CategoriaAgenda { get; set; } = null!;
    public string Usuario { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string AgendaAreaActuacion { get; set; } = null!;
}