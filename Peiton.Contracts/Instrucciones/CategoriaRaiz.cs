namespace Peiton.Contracts.Instrucciones;

public class CategoriaRaiz : Categoria
{
    public IEnumerable<Categoria> Categorias { get; set; } = null!;
}