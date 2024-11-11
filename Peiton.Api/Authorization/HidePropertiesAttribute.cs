using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peiton.Core;
using Peiton.Serialization;

namespace Peiton.Api.Authorization;

public class HidePropertiesByRoleAttribute : ServiceFilterAttribute
{
    public HidePropertiesByRoleAttribute()
        : base(typeof(HidePropertiesByRoleFilter))
    {

    }
}

public class HidePropertiesByRoleFilter(IIdentityService identityService) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var executedContext = await next();

        if (executedContext.Result is ObjectResult objectResult && objectResult.Value != null)
        {
            var result = objectResult.Value;
            var resultType = result.GetType();

            IDictionary<string, object?> expando = new ExpandoObject();

            foreach (var property in resultType.GetProperties())
            {
                var customAttributes = property.GetCustomAttributes(typeof(SerializeIfAttribute), true);
                if (customAttributes.Any())
                {
                    var customAttribute = (SerializeIfAttribute)customAttributes.First();
                    if (await identityService.HasPermissionAsync(customAttribute.Permission))
                    {
                        expando.Add(property.Name, property.GetValue(result));
                    }
                }
                else
                {
                    expando.Add(property.Name, property.GetValue(result));
                }
            }

            executedContext.Result = new ObjectResult((dynamic)expando)
            {
                ContentTypes = objectResult.ContentTypes,
                Formatters = objectResult.Formatters,
                StatusCode = objectResult.StatusCode,
                DeclaredType = objectResult.DeclaredType,
            };
        }
    }
}

