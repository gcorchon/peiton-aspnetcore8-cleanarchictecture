using MassTransit;
using Peiton.Contracts.Categorizacion;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Categorizacion;
[Injectable]
public class TestRuleHandler(IBus bus)
{
    public async Task HandleAsync(TestRuleRequest request)
    {
        await bus.Publish(request);
    }
}
