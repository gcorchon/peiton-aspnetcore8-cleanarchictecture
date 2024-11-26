using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class CertificadoPdfHandler(CertificadoDataExtractor extractor, IPDFService pdfService)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, int entidadFinancieraId, DateTime fechaCertificado)
    {
        var datos = await extractor.HandleAsync(tuteladoId, entidadFinancieraId, fechaCertificado);
        return await pdfService.RenderAsync("Views/ProductosBancarios/certificado-bancario-pdf.cshtml", datos);
    }
}