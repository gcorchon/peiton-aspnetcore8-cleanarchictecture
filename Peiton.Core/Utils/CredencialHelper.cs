using Peiton.Contracts.Credenciales;

public static class CredencialHelper
{
    public static IEnumerable<CampoCredencial> ObtenerCampos(string campos, string datosConexionCifrados)
    {
        var credenciales = Cryptography.Decrypt(datosConexionCifrados);
        if (credenciales == null) return [];

        var dic = (from campo in campos.Split('|')
                   let fields = campo.Split(':')
                   select fields).ToDictionary(k => k[0], v => v[1]);

        var parametros = new List<CampoCredencial>();
        foreach (var campo in credenciales.Split('|'))
        {
            var fields = campo.Split(':');
            if (dic.TryGetValue(fields[0], out string? key))
            {
                parametros.Add(new CampoCredencial
                {
                    Etiqueta = dic[key],
                    Campo = key,
                    Valor = fields[1]
                });
            }

        }

        return parametros.AsEnumerable();
    }

    public static string CodificarCampos(Dictionary<string, string> campos)
    {
        var cadena = string.Join("|", campos.Select(kv => $"{kv.Key}:{kv.Value}"));
        return Cryptography.Encrypt(cadena)!;
    }
}