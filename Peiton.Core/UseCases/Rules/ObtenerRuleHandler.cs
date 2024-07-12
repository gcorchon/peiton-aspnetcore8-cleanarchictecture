using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Rules
{
    [Injectable]
    public class ObtenerRuleHandler(IRuleRepository ruleRepository)
    {
        public async Task HandleAsync(int ruleId, int newPosition)
        {
            var rule = await ruleRepository.GetByIdAsync(ruleId);

            if (rule == null)
            {
                throw new EntityNotFoundException($"No exite la regla con Id {ruleId}");
            }
            
            
            
        }
    }
}
