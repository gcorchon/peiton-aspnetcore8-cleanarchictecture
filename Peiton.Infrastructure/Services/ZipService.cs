using Microsoft.Extensions.DependencyInjection;
using Peiton.Core;
using Peiton.DependencyInjection;
using System.IO.Compression;

namespace Peiton.Infrastructure.Services;

[Injectable(typeof(IZipService), ServiceLifetime.Transient)]
public class ZipService : IZipService, IDisposable
{
    private readonly MemoryStream memoryStream;
    private readonly ZipArchive zipArchive;


    public ZipService()
    {
        memoryStream = new MemoryStream();
        zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);
    }

    public async Task AddFromDataAsync(string entryName, byte[] data)
    {
        var zipEntry = zipArchive.CreateEntry(entryName);
        using Stream entryStream = zipEntry.Open();
        await entryStream.WriteAsync(data, 0, data.Length);
    }

    public void AddFromFile(string entryName, string filePath)
    {
        zipArchive.CreateEntryFromFile(filePath, entryName);
    }

    public byte[] Save()
    {
        zipArchive.Dispose();
        return memoryStream.ToArray();
    }
    public void Dispose()
    {
        this.zipArchive?.Dispose();
        this.memoryStream?.Dispose();
    }

}