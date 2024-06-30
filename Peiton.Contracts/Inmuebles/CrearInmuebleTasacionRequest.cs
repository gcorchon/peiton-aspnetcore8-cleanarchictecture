namespace Peiton.Contracts.Inmuebles
{
    public class CrearInmuebleTasacionRequest
    {
        public int TipoTasacionId { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
