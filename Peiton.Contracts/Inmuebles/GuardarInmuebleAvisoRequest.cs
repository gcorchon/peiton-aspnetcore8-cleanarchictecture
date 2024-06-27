using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Inmuebles
{
    public class GuardarInmuebleAvisoRequest
    {
        public DateTime? FechaVisitaPrevia { get; set; }
        public DateTime? FechaVisitaGI { get; set; }
        public DateTime? FechaVisitaEmpresa { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string InformeInicialGestionItinerante { get; set; } = null!;
        public string ObservacionesDepartamentoAvisos { get; set; } = null!;
        public string InformeFinalGestionItinerante { get; set; } = null!;
        public bool CambioCerradura { get; set; }
        public bool AccesoImposible { get; set; }
        public string ObservacionesFacturacion { get; set; } = null!;
        public bool Resuelto { get; set; }
        public bool EnTramite { get; set; }
        public Coste[] Costes { get; set; } = [];
    }
}
