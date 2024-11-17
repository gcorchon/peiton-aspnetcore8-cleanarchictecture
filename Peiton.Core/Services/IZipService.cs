
namespace Peiton.Core;

public interface IZipService
{
    void AddFromFile(string entryName, string filePath);
    Task AddFromDataAsync(string entryName, byte[] data);
    byte[] Save();
}
