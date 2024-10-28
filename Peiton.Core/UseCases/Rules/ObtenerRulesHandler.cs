using Peiton.Contracts.Rules;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Rules;
[Injectable]
public class ObtenerRulesHandler(IRuleRepository ruleRepository)
{
    public Task<RuleViewModel[]> HandleAsync()
    {
        return ruleRepository.ObtenerRulesAsync();
    }
}
