using Microsoft.AspNetCore.Mvc;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Contracts.Categorizacion;
using Peiton.Core.UseCases.Categorizacion;

namespace Peiton.Api.Contabilidad;

[ApiController]
[PeitonAuthorization(PeitonPermission.Categorizador)]
[Route("api/[controller]")]
public class CategorizacionController : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> ProbarReglaAsync([FromBody]TestRuleRequest data, TestRuleHandler handler)
    {
        await handler.HandleAsync(data);
        
        return Accepted();
    }
}
