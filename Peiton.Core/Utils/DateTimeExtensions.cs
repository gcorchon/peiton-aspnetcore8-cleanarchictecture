namespace Peiton.Core.Utils;
public static class DateTimeExtensions
{
    public static string ToReadableFormat(this DateTime fecha)
    {
        return fecha.Day.ToString() + " de " + fecha.ToString("MMMM").ToLower() + " de " + fecha.Year.ToString();
    }
}