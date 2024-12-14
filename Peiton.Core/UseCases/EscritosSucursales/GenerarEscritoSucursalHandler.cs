using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EscritosSucursales;

[Injectable]
public class GenerarEscritoSucursalHandler(
                ITuteladoRepository tuteladoRepository, ISucursalRepository sucursalRepository,
                IAccountRepository accountRepository, IWordService wordService, IOptions<AppSettings> appSettings)
{
    public async Task<ArchivoViewModel> HandleAsync(int tuteladoId, GenerarEscritoSucursalRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        var datosJuridicos = tutelado.DatosJuridicos ?? throw new ArgumentException("El tutelado no tiene datos jurídicos");
        var juzgado = datosJuridicos.Juzgado ?? throw new ArgumentException("El tutelado no tiene juzgado asignado");
        var nombramiento = datosJuridicos.Nombramiento ?? throw new ArgumentException("El tutelado no tiene un cargo jurado");
        var sucursal = await sucursalRepository.ObtenerSucursalAsync(request.EntidadFinancieraId, request.Numero) ?? throw new NotFoundException("Sucursal no encontrada");

        var accounts = await accountRepository.ObtenerAccountsOficinaActivasAsync(tuteladoId, request.EntidadFinancieraId, request.Numero);

        var ibans = accounts.Select(a => a.Iban);

        string numerosDeCuenta;
        if (ibans.Count() == 1) numerosDeCuenta = ibans.First()!;
        else if (ibans.Count() > 1) numerosDeCuenta = string.Join(", ", ibans, 0, ibans.Count() - 1) + " y " + ibans.Last();

        string template = "";
        string docDescription = "";

        if (request.BloqueoCuentasSI)
        {
            docDescription = "Bloqueo de cuentas SI";
            template = request.SolicitarClave ? "Bloqueo SI_Claves BE.docx" : "Bloqueo SI.docx";
        }
        else if (request.BloqueoCuentasNO)
        {
            docDescription = "Bloqueo de cuentas NO";
            template = request.SolicitarClave ? "Bloqueo NO_Claves BE.docx" : "Bloqueo NO.docx";
        }
        else if (request.SolicitarClave)
        {
            docDescription = "Solicitar clave";
            template = "Solicitud de claves BE.docx";
        }
        else if (request.CartaJuzgado)
        {
            //¿Y esto que es?
        }
        else if (request.BajaSinClaves)
        {
            docDescription = "Baja sin claves";
            template = "Fallecimiento sin claves BE.docx";
        }
        else if (request.DepuracionTitular)
        {
            docDescription = "Depuración titular";
            template = "1-MODELO BANCOS TITULAR.docx";
        }
        else if (request.DepuracionCotitular)
        {
            docDescription = "Depuración cotitular";
            template = "2-MODELO BANCOS COTITULAR.docx";
        }
        else if (request.SolicitudExtracto)
        {
            docDescription = "Solicitud extracto";
            template = "Solicitud extracto.docx";
        }
        else if (request.AperturaCuenta)
        {
            docDescription = "Apertura cuenta";
            template = "Apertura1Cuenta.docx";
        }
        else if (request.Apertura2Cuentas)
        {
            docDescription = "Apertura 2 cuentas";
            template = "Apertura2Cuentas.docx";
        }
        else if (request.SolicitudSantander300)
        {
            docDescription = "Solicitud Santander 300";
            template = "Solicitud Santander 300.docx";
        }
        else if (request.SolicitudBastanteo)
        {
            docDescription = "Solicitud Bastanteo";
            template = "Solicitud Bastanteo.docx";
        }
        else if (request.EscritoGeneral)
        {
            docDescription = "Solicitud Bastanteo";
            template = "Comunicacion a bancos.docx";
        }

        var templatePath = $"App_Data/Escritos_Bancos/{appSettings.Value.Cliente}/{template}";

        var data = await wordService.RenderAsync(templatePath,
            new Dictionary<string, string>() {
                {"[ENTIDAD]", sucursal.EntidadFinanciera.Descripcion },
                {"[SUCURSAL]", sucursal.Numero },
                {"[DirecciónSucursal]", sucursal.Direccion },
                {"[CPSucursal]", sucursal.CodigoPostal },
                {"[ProvinciaSucursal]", sucursal.Provincia },
                {"[Número de Expediente]", tutelado.NumeroExpediente },
                {"[Firma Económico]", tutelado.Economico != null ? tutelado.Economico.Clave : "" },
                {"[mail trabajador económico]",  tutelado.Economico != null ? (tutelado.Economico.Email ?? "") : "" },
                {"[FECHA ACTUAL]", DateTime.Now.ToReadableFormat() },
                {"[Fecha Nombramiento]", datosJuridicos.FechaNombramiento.HasValue ? datosJuridicos.FechaNombramiento.Value.ToReadableFormat(): "[Fecha Nombramiento]" },
                {"[Fecha Sentencia]", datosJuridicos.FechaSentencia.HasValue ?  datosJuridicos.FechaSentencia.Value.ToReadableFormat(): "[FECHA SENTENCIA]" },
                {"[FECHA SENTENCIA]", datosJuridicos.FechaSentencia.HasValue ? datosJuridicos.FechaSentencia.Value.ToReadableFormat(): "[FECHA SENTENCIA]" },
                {"[FECHA JURA]", datosJuridicos.FechaJura.HasValue ? datosJuridicos.FechaJura.Value.ToReadableFormat(): "[FECHA JURA]" },
                {"[Fecha de Jura]", datosJuridicos.FechaJura != null?  datosJuridicos.FechaJura.Value.ToReadableFormat() : "[FECHA JURA]" },
                {"[Juzgado]", datosJuridicos.Juzgado.Descripcion },
                {"[JUZGADO]", datosJuridicos.Juzgado.Descripcion },
                {"[Nombramiento]", nombramiento.Descripcion },
                {"[NOMBRAMIENTO]", nombramiento.Descripcion },
                {"[NOMBRE]", (tutelado.Sexo == "H" ? "D. " : "Dña. ") + tutelado.Nombre.ToUpper() },
                {"[APELLIDOS]", (tutelado.Apellidos ?? "").ToUpper() },
                {"[NOMBRE COMPLETO]", (tutelado.Sexo == "H" ? "D. " : "Dña. ") + tutelado.Nombre.ToUpper() + " " + (tutelado.Apellidos ?? "").ToUpper() },
                {"[DNI]", tutelado.DNI ?? "[DNI]" },
                {"[FechaMuerto]", tutelado.FechaMuerto.HasValue ? tutelado.FechaMuerto.Value.ToReadableFormat() : "" }
            });

        return new ArchivoViewModel()
        {
            Data = data,
            MimeType = MimeTypeHelper.Word,
            FileName = $"{tutelado.Apellidos} {tutelado.Nombre} {docDescription}.docx"
        };
    }
}