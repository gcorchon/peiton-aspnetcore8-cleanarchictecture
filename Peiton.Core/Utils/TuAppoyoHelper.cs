using System.Security.Cryptography;
using System.Text;

namespace Peiton.Core.Utils;

public class TuAppoyoHelper
{
    public static string HashPassword(string value){
        var bytes = Encoding.UTF8.GetBytes(value + "TeAppoyo2023!");
        var hashedBytes = SHA256.HashData(bytes);
        return Convert.ToBase64String(hashedBytes);
    }
}