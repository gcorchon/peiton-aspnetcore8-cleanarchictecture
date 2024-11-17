using Peiton.Contracts.Common;

namespace Peiton.Contracts.FondosSolidarios;

public class FondoSolidarioExtendidoViewModel
{
    public string FondoSolidarioTipoFondo { get; set; } = null!;
    public string FondoSolidarioPeriodicidad { get; set; } = null!;
    public string FondoSolidarioDestino { get; set; } = null!;
    public string? FondoSolidarioFormaPago { get; set; }
    public string Solicitante { get; set; } = null!;
    public string? Revisor { get; set; }
    public string? Autorizador { get; set; }
    public string? Pagador { get; set; }
    public string? Verificador { get; set; }
    public decimal Importe { get; set; }
    public string ObservacionesSolicitud { get; set; } = null!;
    public string? ObservacionesAutorizacion { get; set; }
    public bool FamiliaContribuye { get; set; }
    public string? Archivo { get; set; }
    public bool Revisado { get; set; }
    public bool Autorizado { get; set; }
    public bool Pagado { get; set; }
    public bool Verificado { get; set; }
    public bool Rechazado { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRevision { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaCaducidad { get; set; }
    public DateTime? FechaPago { get; set; }
    public bool Recuperable { get; set; }
    public DateTime? FechaVerificacion { get; set; }
    public int? FondoSolidarioTarjetaPrepagoId { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Archivo2 { get; set; }

}