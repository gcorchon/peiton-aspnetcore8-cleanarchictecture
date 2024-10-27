using Peiton.Contracts.Senalamientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class ProfesionalesHandler(IDbService dbService)
{
    public async Task<IEnumerable<string>> HandleAsync(string text)
    {
        return await dbService.QueryAsync<string>(@"select top 8 nombre from (
                                                select Descripcion as Nombre from ReferenteDF
                                                union 
                                                select Nombre from TecnicoIntegracionSocial
                                                union
                                                select Nombre from TrabajadorSocial
                                                union
                                                select Nombre from CoordinadorSocial
                                                union
                                                select Nombre from EducadorSocial
                                                union                           
                                                select Nombre from Abogado
                                                union                           
                                                select Nombre from Economico
                                                ) dv where Nombre like @text order by 1", new { text = "%" + text + "%" });
    }
}