using Peiton.Contracts.Bancos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales
{
    [Injectable]
    public class CredencialBloqueadaHandler(ICredencialRepository credencialRepository, ICryptographyService cryptographyService)
    {
        public async Task<IEnumerable<CampoCredencial>> HandleAsync(int id)
        {
            /*return await Task.FromResult(new List<CampoCredencial>()
            {
                new CampoCredencial()
                {
                    Descripcion = "Nombre",
                    Valor = cryptographyService.Decrypt(cryptographyService.Encrypt("Gonzalo Corchón Duaygües Crespo Batiste Gil Buyo Barranco Estradé Pérez Largo"))
                },
                new CampoCredencial()
                {
                    Descripcion = "Cifrado",
                    Valor = cryptographyService.Encrypt("Gonzalo Corchón Duaygües Crespo Batiste Gil Buyo Barranco Estradé Pérez Largo")
                }
            });*/

            var credencial = await credencialRepository.GetByIdAsync(id);
            if (credencial == null) throw new NotFoundException();

            string campos = credencial.EntidadFinanciera.Campos;
            string credenciales = credencial.DatosConexion;
            credenciales = cryptographyService.Decrypt(credenciales);

            var dic = (from campo in campos.Split('|')
                       let fields = campo.Split(':')
                       select fields).ToDictionary(k => k[0], v => v[1]);

            var parametros = new List<CampoCredencial>();
            foreach (var campo in credenciales.Split('|'))
            {
                var fields = campo.Split(':');
                if (dic.ContainsKey(fields[0]))
                {
                    parametros.Add(new CampoCredencial
                    {
                        Descripcion = dic[fields[0]],
                        Valor = fields[1]
                    });
                }
            }
            return parametros;
        }
    }



}
