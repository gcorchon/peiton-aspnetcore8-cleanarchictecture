namespace Peiton.Contracts.InformesPatrimoniales;

public class GenerarInformePatrimonialRequest
{
    public int TuteladoId { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public bool SolicitarRetribucion { get; set; }
}