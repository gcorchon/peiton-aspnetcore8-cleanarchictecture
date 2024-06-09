using System.Security.Cryptography;
using System.Text;
using Peiton.DependencyInjection;

namespace Peiton.Core.Services;

[Injectable(typeof(ICryptographyService))]
public class CryptographyService : ICryptographyService
{
    public string GetMd5Hash(string input)
    {
        var sBuilder = new StringBuilder();
        using (var md5Hash = MD5.Create())
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
        }

        return sBuilder.ToString();
    }
}