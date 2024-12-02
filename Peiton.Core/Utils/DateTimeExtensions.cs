namespace Peiton.Core.Utils;
public static class DateTimeExtensions
{
    public static string ToReadableFormat(this DateTime fecha)
    {
        return fecha.ToString("dd 'de' MMMM 'de' yyyy").ToLower();
    }
}