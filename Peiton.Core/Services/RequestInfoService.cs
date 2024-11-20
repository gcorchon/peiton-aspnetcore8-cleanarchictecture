using Microsoft.AspNetCore.Http;
using Peiton.DependencyInjection;

namespace Peiton.Core.Services;

[Injectable]
public class RequestInfoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RequestInfoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetRequestUrl()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        if (request == null)
        {
            return "No se pudo obtener el contexto de la petición.";
        }

        var host = request.Host.Value; // Obtiene el dominio (host y puerto)
        var path = request.Path;       // Obtiene el path de la URL actual

        var scheme = request.Scheme;   // Obtiene el esquema (http o https)

        return $"{scheme}://{host}{path}";
    }
}
