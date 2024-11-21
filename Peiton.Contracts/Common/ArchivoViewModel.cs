namespace Peiton.Contracts.Common;

public class ArchivoViewModel
{
    public string FileName { get; set; } = null!;
    public byte[] Data { get; set; } = null!;
    public string MimeType { get; set; } = null!;
}