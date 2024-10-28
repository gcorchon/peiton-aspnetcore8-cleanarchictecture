using Peiton.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Core.Repositories;
public interface IVwCategoriaRepository
{
    Task<VwCategoria[]> BuscarCategoriasAsync(string text, int total);
    Task<VwCategoria[]> ObtenerCategoriasAsync();
}
