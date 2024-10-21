namespace Peiton.Contracts.Documentos;

public class CategoriaRaiz : Categoria
{
    public IEnumerable<Categoria> Categorias { get; set; } = null!;
}