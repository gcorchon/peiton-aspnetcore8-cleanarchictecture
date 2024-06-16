using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Caja
{
    public class ReintegroExcelListItem
    {
        public string NombreCompleto { get; set; } = "";
        public string? Numero { get; set; } = "";
        public decimal? Saldo { get; set; }
        public decimal? Importe { get; set; }
    }
}
