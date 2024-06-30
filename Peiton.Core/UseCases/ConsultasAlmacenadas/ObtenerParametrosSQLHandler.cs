using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Text.RegularExpressions;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ObtenerParametrosSQLHandler
{
    public Task<IEnumerable<string>> HandleAsync(string query)
    {
        var matches = Regex.Matches(query, "(@[a-zA-Z0-9ñÑ_][a-zA-Z0-9ñÑ_]*)");
        var queryParameters = new List<string>();
        foreach (Match match in matches)
        {
            queryParameters.Add(match.Value);
        }

        return Task.FromResult(queryParameters.Distinct(StringComparer.InvariantCultureIgnoreCase));
    }

}