using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Rules
{
    public class RuleViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string? BankCssClass { get; set; }
    }
}
