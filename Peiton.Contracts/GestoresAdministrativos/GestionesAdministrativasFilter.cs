namespace Peiton.Contracts.GestoresAdministrativos
{
    public class GestionesAdministrativasFilter
    {
        public int? Id { get; set; }
        public string? Tutelado { get; set; }
        public string? Trabajador { get; set; }
        public int? Tipo { get; set; }
        public int? Estado { get; set; }
    }
}
