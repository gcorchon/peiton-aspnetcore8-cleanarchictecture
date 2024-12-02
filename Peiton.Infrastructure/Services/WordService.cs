using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Peiton.Core;
using Peiton.DependencyInjection;
using System.IO.Compression;
using Peiton.Core.Exceptions;

namespace Peiton.Infrastructure.Services;

[Injectable(typeof(IWordService), ServiceLifetime.Singleton)]
public class WordService(IRazorService razorService) : IWordService
{
    public async Task<byte[]> RenderAsync(string docxPath, Dictionary<string, string> data)
    {
        if (!File.Exists(docxPath)) throw new NotFoundException("No se ha encontrado la plantilla");
        var resourceStream = File.Open(docxPath, FileMode.Open);
        var outputStream = new MemoryStream();

        using (var archive = new ZipArchive(resourceStream, ZipArchiveMode.Read, false))
        {
            using var outputArchive = new ZipArchive(outputStream, ZipArchiveMode.Create, true);
            foreach (var entry in archive.Entries)
            {
                var newEntry = outputArchive.CreateEntry(entry.FullName);

                if (entry.FullName.EndsWith(".xml"))
                {
                    using var reader = new StreamReader(entry.Open(), Encoding.UTF8);
                    var docxPartContent = await reader.ReadToEndAsync();
                    var templateContent = Replace(docxPartContent, data);

                    using var writer = new StreamWriter(newEntry.Open(), Encoding.UTF8);
                    await writer.WriteAsync(templateContent);
                }
                else
                {
                    using var entryStream = entry.Open();
                    using var newEntryStream = newEntry.Open();
                    await entryStream.CopyToAsync(newEntryStream);
                }
            }
        }

        outputStream.Position = 0;
        return outputStream.ToArray();
    }

    public async Task<byte[]> RenderAsync<T>(string docxPath, Dictionary<string, string> data, T model)
    {
        if (!File.Exists(docxPath)) throw new NotFoundException("No se ha encontrado la plantilla");
        var resourceStream = File.Open(docxPath, FileMode.Open);
        var outputStream = new MemoryStream();

        using (var archive = new ZipArchive(resourceStream, ZipArchiveMode.Read, false))
        {
            using var outputArchive = new ZipArchive(outputStream, ZipArchiveMode.Create, true);
            foreach (var entry in archive.Entries)
            {
                var newEntry = outputArchive.CreateEntry(entry.FullName);

                if (entry.FullName.EndsWith(".xml"))
                {
                    using var reader = new StreamReader(entry.Open(), Encoding.UTF8);
                    var docxPartContent = await reader.ReadToEndAsync();
                    //Reemplazar primero los tags planos
                    var templateContent = Replace(docxPartContent, data);
                    //Aplicar la programación de Razor
                    templateContent = await ProcessAsync(templateContent, model);
                    using var writer = new StreamWriter(newEntry.Open(), Encoding.UTF8);
                    await writer.WriteAsync(templateContent);
                }
                else
                {
                    using var entryStream = entry.Open();
                    using var newEntryStream = newEntry.Open();
                    await entryStream.CopyToAsync(newEntryStream);
                }
            }
        }

        outputStream.Position = 0;
        return outputStream.ToArray();
    }

    public async Task<byte[]> RenderRazorAsync<T>(string docxPath, T data)
    {
        var resourceStream = File.Open(docxPath, FileMode.Open);
        var outputStream = new MemoryStream();

        using (var archive = new ZipArchive(resourceStream, ZipArchiveMode.Read, false))
        {
            using var outputArchive = new ZipArchive(outputStream, ZipArchiveMode.Create, true);
            foreach (var entry in archive.Entries)
            {
                var newEntry = outputArchive.CreateEntry(entry.FullName);

                if (entry.FullName.EndsWith(".xml"))
                {
                    using var reader = new StreamReader(entry.Open(), Encoding.UTF8);
                    var docxPartContent = await reader.ReadToEndAsync();
                    var templateContent = await ProcessAsync(docxPartContent, data);

                    using var writer = new StreamWriter(newEntry.Open(), Encoding.UTF8);
                    await writer.WriteAsync(templateContent);
                }
                else
                {
                    using var entryStream = entry.Open();
                    using var newEntryStream = newEntry.Open();
                    await entryStream.CopyToAsync(newEntryStream);
                }
            }
        }

        outputStream.Position = 0;
        return outputStream.ToArray();
    }

    private async Task<string> ProcessAsync<T>(string sourceTemplate, T data)
    {
        var modelType = typeof(T).FullName;

        var template = @$"@using RazorLight
@inherits TemplatePage<{modelType}>
@using System
@using System.Linq
@using Peiton.Core.Utils
{sourceTemplate}";
        return await razorService.RenderTemplateAsync(template, data);
    }


    public string Replace(string sourceTemplate, Dictionary<string, string> data)
    {
        var strb = new StringBuilder(sourceTemplate);
        foreach (string key in data.Keys)
        {
            strb.Replace(key, data[key]);
        }
        return strb.ToString();
    }
}