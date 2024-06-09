namespace Peiton.Contracts.Asientos
{
    public class FondosFilter
    {
        public string? Tutelado { get; set; }
        public string? Dni { get; set; }
        public string? Ingresos { get; set; }
        public string? Gastos { get; set; }
        public string? Diferencia { get; set; }
    }

    public class CapituloPartidaFilter
    {
        public string Capitulo { get; set; } = null!;
        public string Partida { get; set; } = null!;
    }
}
