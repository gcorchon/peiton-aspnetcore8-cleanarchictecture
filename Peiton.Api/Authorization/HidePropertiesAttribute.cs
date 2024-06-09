using System.Collections.Immutable;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peiton.Core;
using Peiton.Core.Repositories;
using Peiton.Serialization;

namespace Peiton.Api.Authorization
{
    public class HidePropertiesByRoleAttribute : ServiceFilterAttribute
    {
        public HidePropertiesByRoleAttribute()
            : base(typeof(HidePropertiesByRoleFilter))
        {

        }
    }

    public class HidePropertiesByRoleFilter : Attribute, IActionFilter
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IIdentityService identityService;

        public HidePropertiesByRoleFilter(IUsuarioRepository usuarioRepository, IIdentityService identityService)
        {
            this.usuarioRepository = usuarioRepository;
            this.identityService = identityService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No es necesario implementar esta interfaz si no necesitas lógica antes de la ejecución del método del controlador
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var result = objectResult.Value;
                var resultType = result.GetType();

                IDictionary<string, object?> expando = new ExpandoObject();

                int? userId = identityService.GetUserId();
                if(userId is null) throw new Exception("User not authenticated");

                var permissions = usuarioRepository.GetPermissions(userId.Value).ToImmutableSortedSet()!;
                
                foreach (var property in resultType.GetProperties())
                {
                    var customAttributes = property.GetCustomAttributes(typeof(SerializeIfAttribute), true);
                    if (customAttributes.Any())
                    {
                        var customAttribute = (SerializeIfAttribute)customAttributes.First();
                        if (permissions.Contains(customAttribute.Permission))
                        {
                            expando.Add(property.Name, property.GetValue(result));
                        }
                    } 
                    else
                    {
                        expando.Add(property.Name, property.GetValue(result));
                    }
                }
                
                context.Result = new ObjectResult((dynamic)expando)
                {
                    ContentTypes = objectResult.ContentTypes,
                    Formatters = objectResult.Formatters,
                    StatusCode = objectResult.StatusCode,
                    DeclaredType = objectResult.DeclaredType,
                };               
            }
        }
    }
}
