namespace Peiton.Contracts.DocumentosGenerados;

public class CategoriaRaiz : Categoria
{
    public IEnumerable<Categoria> Categorias { get; set; } = null!;
}