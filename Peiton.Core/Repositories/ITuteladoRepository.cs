using Peiton.Contracts.Tutelados;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ITuteladoRepository : IRepository<Tutelado>
{
	Task<Tutelado[]> ObtenerTuteladosAsync(int page, int total, TuteladosFilter filter);
	Task<int> ContarTuteladosAsync(TuteladosFilter filter);
	Task<Tutelado[]> ObtenerTuteladosParaReintegrosAsync(string text);
	Task<Tutelado[]> ObtenerTuteladosPorNombreAsync(string query, int total);

	Task<bool> CanViewAsync(int id);
	Task<bool> CanModifyAsync(int id);
}
