using AutoMapper;
using Peiton.Contracts.Bancos;
using Peiton.Contracts.Excel;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales
{
    [Injectable]
    public class ExportarCredencialesBloqueadasHandler(ICredencialRepository credencialRepository, IMapper mapper, IExcelService excelService)
    {
        public async Task<byte[]> HandleAsync(CredencialesBloqueadasFilter filter)
        {
            var credenciales = await credencialRepository.ObtenerCredencialesBloqueadasAsync(filter);
            var vm = mapper.Map<IEnumerable<CredencialBloquedaListItem>>(credenciales);

            var columns = new ColumnaExcel[]
            {
                new ("Nº Exp", "NumeroExpediente"),
                new ("DNI", "Dni"),
                new ("Nombre", "Tutelado"),
                new ("Banco", "EntidadFinanciera"),
                new ("Nombramiento", "Nombramiento"),
                new ("Última ej. correcta", "UltimaEjecucionCorrecta"),
            };

            return excelService.Export(vm, columns);
        }

    }



}
