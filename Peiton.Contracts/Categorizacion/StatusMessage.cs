using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Categorizacion
{
    public class StatusMessage
    {
        public string Type { get; set; } = null!;
        public dynamic Data { get; set; } = null!;
    }
}
