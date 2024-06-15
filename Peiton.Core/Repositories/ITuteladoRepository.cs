using Peiton.Core.Entities;

namespace Peiton.Core.Repositories
{
	public interface ITuteladoRepository : IRepository<Tutelado>
	{
		Task<List<Tutelado>> ObtenerTuteladosParaReintegrosAsync(string text);
	}
}