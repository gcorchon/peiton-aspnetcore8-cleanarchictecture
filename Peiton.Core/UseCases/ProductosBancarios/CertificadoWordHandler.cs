using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class CertificadoWordHandler(CertificadoDataExtractor extractor, IWordService wordService)
{
    public async Task<byte[]> HandleAsync(int tuteladoId, int entidadFinancieraId, DateTime fechaCertificado)
    {
        var datos = await extractor.HandleAsync(tuteladoId, entidadFinancieraId, fechaCertificado);
        return await wordService.RenderRazorAsync("App_Data/certificado-bancario.docx", datos);
    }
}