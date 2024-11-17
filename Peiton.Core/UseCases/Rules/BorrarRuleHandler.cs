using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Rules;
[Injectable]
public class BorrarRuleHandler(IRuleRepository ruleRepository)
{
    public async Task HandleAsync(int ruleId)
    {
        var rule = await ruleRepository.GetByIdAsync(ruleId);

        if (rule == null)
        {
            throw new NotFoundException($"No exite la regla con Id {ruleId}");
        }

        await ruleRepository.BorrarReglaAsync(ruleId);
    }
}
