using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.Contracts.Asientos;

public class CertificadoIngresosGastosRequest
{
    [BindRequired]
    public int TuteladoId { get; set; }

    [BindRequired]
    public DateTime Fecha { get; set; }
}