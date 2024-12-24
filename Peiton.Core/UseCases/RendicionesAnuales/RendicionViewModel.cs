using Peiton.Contracts.Account;
using Peiton.Contracts.Loans;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Entities;

namespace Peiton.Core.UseCases.RendicionesAnuales;

public class RendicionViewModel : RendicionBase
{
    //public IEnumerable<SueldoPension> SueldosYPensiones { get; set; } = [];
    public IEnumerable<ProductoBancarioConSaldoListItem> Productos { get; set; } = [];
    public IEnumerable<Inmueble> Inmuebles { get; set; } = [];
    public IEnumerable<Arrendamiento> Arrendamientos { get; set; } = [];
    public IEnumerable<LoanRendicionViewModel> Prestamos { get; set; } = [];
    public decimal ImporteDeudas { get; set; }
    public IEnumerable<JustificacionIngresosYGastos> JustificacionIngresosYGastos { get; set; } = [];
    public decimal Retribucion { get; set; }
    public bool MostrarRetribucion { get; set; }
}