namespace Peiton.Contracts.GestoresAdministrativos
{
    public class GestionAdministrativaListItem
    {
        public int Id { get; set; }
        public string Trabajador { get; set; } = null!;
        public string Tutelado { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
