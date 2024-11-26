using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.Contracts.ProductosBancarios;

public class CertificadoRequest
{
    [BindRequired]
    public int TuteladoId { get; set; }

    [BindRequired]
    public int EntidadFinancieraId { get; set; }

    [BindRequired]
    public DateTime Fecha { get; set; }


}