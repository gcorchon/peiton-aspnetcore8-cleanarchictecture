using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class TuteladosReintegrosHandler(ITuteladoRepository tuteladoRepository)
{
    public Task<List<Tutelado>> HandleAsync(string text)
    {
        return tuteladoRepository.ObtenerTuteladosParaReintegrosAsync(text);
    }
}