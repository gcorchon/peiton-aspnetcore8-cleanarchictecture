using System.Text.Json.Serialization;

namespace Peiton.Contracts.Categorias
{
    public class CategoryTree
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<CategoryTree> Subcategorias { get; set; } = null!;
    }
}
