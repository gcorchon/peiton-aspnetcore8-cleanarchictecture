using Peiton.Contracts.Rules;
using Peiton.Core.Entities;

namespace Peiton.Core.Repositories;
public interface IRuleRepository : IRepository<Rule>
{
    Task BorrarReglaAsync(int ruleId);
    Task<RuleViewModel[]> ObtenerRulesAsync();
    Task ReordenarReglaAsync(int ruleId, int newPosition);
}
