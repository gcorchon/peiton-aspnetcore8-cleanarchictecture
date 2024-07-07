namespace Peiton.Contracts.Categorizacion
{
    public class TestRuleRequest
    {
        /// <summary>
        /// Modo de ejecutar la regla (1 - Sin categorizar, 2 - Categorizados, 3 - Todos
        /// </summary>
        public int Which { get; set; } = 1; 
        public int? Bank { get; set; }
        public WhereData Where { get; set; } = new();
        public string What { get; set; } = null!;
        public List<Criteria> CriteriaList { get; set; } = [];
    }

    public class WhereData
    {
        public bool Description { get; set; }
        public bool Reference { get; set; }
        public bool Payer { get; set; }
        public bool Payee { get; set; }
    }

    public class Criteria
    {
        public string ColumnName { get; set; } = null!;
        public string Operator { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
