namespace Peiton.Infrastructure.Utils;

public class WordTableCell
{
    public WordTableCell()
    {
        Align = "left";
    }

    public string Text { get; set; } = null!;

    public int Width { get; set; }

    public string Align { get; set; }
}
