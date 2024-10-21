namespace Peiton.Contracts.Procesos;

public class CategoriaRaiz : Categoria
{
    public IEnumerable<Categoria> Categorias { get; set; } = null!;
}