namespace Peiton.Contracts.FondosSolidarios;

public class ArchivoFondoSolidario
{
    public string FileName { get; set; } = null!;
    public byte[] Data { get; set; } = null!;
    public string MimeType { get; set; } = null!;
}