using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Consultas
{
    public class EjecutarSQLResponse
    {
        public IEnumerable<Column> Columns { get; set; } = new List<Column>();
        public IEnumerable<object[]> Rows { get; set; } = [];
    }

    public class Column
    {
        public string Name { get; set; } = null!;
        public string DataType { get; set; } = null!;
    }
}
