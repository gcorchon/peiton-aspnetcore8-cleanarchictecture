using System.ComponentModel.DataAnnotations;

namespace Peiton.Contracts.Capitulo;

public class CreateCapituloRequest
{
    [MaxLength(1)]
    public string Tipo { get; set; } = null!;

    [MaxLength(20)]
    public string Numero { get; set; } = null!;

    [MaxLength(255)]
    public string Descripcion { get; set; } = null!;

    [Range(1996, int.MaxValue)]
    public int Ano { get; set; }
}