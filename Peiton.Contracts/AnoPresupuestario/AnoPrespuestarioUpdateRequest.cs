using System.ComponentModel.DataAnnotations;

namespace Peiton.Contracts.AnoPresupuestario
{
    public class AnoPrespuestarioUpdateRequest
    {
        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; } = string.Empty;
    }
}
