using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface ITuteladoRepository : IRepository<Tutelado>
{
	Task<Tutelado[]> ObtenerTuteladosParaReintegrosAsync(string text);
	Task<Tutelado[]> ObtenerTuteladosPorNombreAsync(string query, int total);
}
