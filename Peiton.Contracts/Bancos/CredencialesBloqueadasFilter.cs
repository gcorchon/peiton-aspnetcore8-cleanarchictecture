using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Bancos
{
    public class CredencialesBloqueadasFilter
    {
        
        public string? UltimaEjecucionCorrecta { get; set; }
        public string? UltimaEjecucion { get; set; }
        public string? NumeroExpediente { get; set; } 
        public string? Dni { get; set; } 
        public string? EntidadFinanciera { get; set; } 
        public string? Tutelado { get; set; } 
        public string? Nombramiento { get; set; } 
    }
}
