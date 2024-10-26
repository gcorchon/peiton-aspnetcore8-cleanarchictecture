using System.ComponentModel.DataAnnotations;

namespace Peiton.Contracts.Senalamientos;

public class SenalamientosFillter
{
    [Required]
    public int Month { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public bool SoloMadrid { get; set; }

    public string? Tutelado { get; set; }
}