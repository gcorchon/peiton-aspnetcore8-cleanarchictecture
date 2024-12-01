namespace Peiton.Contracts.Archivos;

public class CategoriaRaiz : Categoria
{
    public IEnumerable<Categoria> Categorias { get; set; } = null!;
}