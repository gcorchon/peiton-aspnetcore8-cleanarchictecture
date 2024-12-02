
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.DocumentosGenerados;

[Injectable]
public class GenerarDocumentHandler(IDocumentoGeneradoRepository documentoGeneradoRepository, ITuteladoRepository tuteladoRepository, IWordService wordService, IOptions<AppSettings> appSettings)
{
    public async Task<ArchivoViewModel> HandleAsync(int id, int tuteladoId)
    {
        var documento = await documentoGeneradoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Documento no encontrado");
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        string? direccionResidenciaHabitual = null;
        if (tutelado.ResidenciaHabitual!.Tipo == "D")
        {
            direccionResidenciaHabitual = tutelado.ResidenciaHabitual.DireccionCompleta;
        }
        else if (tutelado.ResidenciaHabitual.Tipo == "C" && tutelado.ResidenciaHabitual.Centro != null)
        {
            var centro = tutelado.ResidenciaHabitual.Centro;
            direccionResidenciaHabitual = $"{centro.Nombre}, {centro.Via} {centro.Direccion} {centro.Numero ?? ""}, {centro.CP} {centro.Poblacion}";
        }

        var dict = new Dictionary<string, string>(){
        {"[TTO]", tutelado.Sexo == "H" ? "D." : "Dña."},
        {"[LETRA SEXO]", tutelado.Sexo == "H" ? "o" : "a"},
        {"[NOMBRE COMPLETO]", tutelado.NombreCompleto ?? ""},
        {"[NOMBRE]", tutelado.Nombre},
        {"[PRIMER APELLIDO]", tutelado.Apellido1 ?? ""},
        {"[SEGUNDO APELLIDO]", tutelado.Apellido2 ?? ""},
        {"[APELLIDOS]", tutelado.Apellidos ?? ""},
        {"[NUMERO EXPEDIENTE]", tutelado.NumeroExpediente},
        {"[ABOGADO]", tutelado.Abogado != null ? tutelado.Abogado.Nombre : "[ABOGADO]"},
        {"[TRABAJADOR SOCIAL]", tutelado.TrabajadorSocial != null ? tutelado.TrabajadorSocial.Nombre : "[TRABAJADOR SOCIAL]"},
        {"[COORDINADOR SOCIAL]", tutelado.CoordinadorSocial!= null ? tutelado.CoordinadorSocial.Nombre : "[COORDINADOR SOCIAL]"},
        {"[DNI]", tutelado.DNI ?? ""},
        {"[FECHA BAJA]", tutelado.FechaMuerto.HasValue ? tutelado.FechaMuerto.Value.ToReadableFormat() : "[FECHA BAJA]"},
        {"[FECHA ACTUAL]", DateTime.Now.ToReadableFormat()},
        {"[AÑO ACTUAL]", DateTime.Now.ToString("yyyy")},
        {"[MUNICIPIO BAJA]", tutelado.MunicipioBaja != null ? tutelado.MunicipioBaja : "[MUNICIPIO BAJA]"},
        {"[LUGAR BAJA]", tutelado.LugarBaja != null ? tutelado.LugarBaja : "[LUGAR BAJA]"},
        {"[NACIONALIDAD]", tutelado.Nacionalidad != null ? tutelado.Nacionalidad.Nombre : "[NACIONALIDAD]"},
        {"[NOMBRE RESIDENCIA]", tutelado.ResidenciaHabitual.Centro != null ? tutelado.ResidenciaHabitual.Centro.Nombre : "[NOMBRE RESIDENCIA]"},
        {"[MEDIDA PROPUESTA]", tutelado.ValoracionMedidaPropuesta != null ? tutelado.ValoracionMedidaPropuesta.Descripcion : "[MEDIDA PROPUESTA]"},
        {"[TUTOR PROPUESTO]", tutelado.ValoracionTutor != null ? tutelado.ValoracionTutor.Descripcion : "[TUTOR PROPUESTO]"},
        {"[DOMICILIO HABITUAL]", direccionResidenciaHabitual ?? "[DOMICILIO HABITUAL]"},
        {"[FECHA NACIMIENTO]", tutelado.FechaNacimiento.HasValue ? tutelado.FechaNacimiento.Value.ToReadableFormat() : "[FECHA NACIMIENTO]"},
        {"[ESTADO CIVIL]", tutelado.EstadoCivil != null ? (tutelado.Sexo == "H" ?  tutelado.EstadoCivil.Descripcion.ToLower() : tutelado.EstadoCivil.DescripcionFemenino!.ToLower()) : "desconocido"}
        };
        /*
                wordDocument.Replace("[SUELDOS Y PENSIONES]", (paragraph, index) =>
                {
                    var renderer = new ViewRenderer();
                    var xml = renderer.RenderPartialViewToString("~/Views/GestionIndividual/Informes/GeneradorDocumentos/_sueldos-pensiones.cshtml", tutelado);
                    var node = WordDocument.XElementFromString("<container>" + xml + "</container>");
                    paragraph.ReplaceWith(node.Elements());
                });

                wordDocument.Replace("[ARRENDAMIENTOS]", (paragraph, index) =>
                {
                    var renderer = new ViewRenderer();
                    var xml = renderer.RenderPartialViewToString("~/Views/GestionIndividual/Informes/GeneradorDocumentos/_arrendamientos.cshtml", tutelado);
                    var node = WordDocument.XElementFromString("<container>" + xml + "</container>");
                    paragraph.ReplaceWith(node.Elements());
                });

                wordDocument.Replace("[CONTACTOS PERSONALES]", (paragraph, index) =>
                {
                    var renderer = new ViewRenderer();
                    var xml = renderer.RenderPartialViewToString("~/Views/GestionIndividual/Informes/GeneradorDocumentos/_contactos-personales.cshtml", tutelado);
                    var node = WordDocument.XElementFromString("<container>" + xml + "</container>");
                    paragraph.ReplaceWith(node.Elements());
                });

                wordDocument.Replace("[CONTACTOS PROFESIONALES]", (paragraph, index) =>
                {
                    var renderer = new ViewRenderer();
                    var xml = renderer.RenderPartialViewToString("~/Views/GestionIndividual/Informes/GeneradorDocumentos/_contactos-profesionales.cshtml", tutelado);
                    var node = WordDocument.XElementFromString("<container>" + xml + "</container>");
                    paragraph.ReplaceWith(node.Elements());
                });
                */

        if (tutelado.DatosJuridicos != null)
        {
            dict.Add("[NUMERO PROCEDIMIENTO]", tutelado.DatosJuridicos.NumeroProcedimiento ?? "[NUMERO PROCEDIMIENTO]");
            dict.Add("[PROCEDIMIENTO]", tutelado.DatosJuridicos.Procedimiento != null ? tutelado.DatosJuridicos.Procedimiento.Descripcion : "[PROCEDIMIENTO]");
            dict.Add("[NOMBRAMIENTO]", tutelado.DatosJuridicos.Nombramiento != null ? tutelado.DatosJuridicos.Nombramiento.Descripcion : "[NOMBRAMIENTO]");
            dict.Add("[FECHAS SENTENCIA]", tutelado.DatosJuridicos.FechaSentencia.HasValue ? tutelado.DatosJuridicos.FechaSentencia.Value.ToReadableFormat() : "[FECHAS SENTENCIA]");
            dict.Add("[FECHA NOMBRAMIENTO]", tutelado.DatosJuridicos.FechaNombramiento.HasValue ? tutelado.DatosJuridicos.FechaNombramiento.Value.ToReadableFormat() : "[FECHA NOMBRAMIENTO]");
            dict.Add("[FECHA JURA]", tutelado.DatosJuridicos.FechaJura.HasValue ? tutelado.DatosJuridicos.FechaJura.Value.ToReadableFormat() : "[FECHA JURA]");

            if (tutelado.DatosJuridicos.Juzgado != null)
            {
                var juzgado = tutelado.DatosJuridicos.Juzgado.Descripcion.ToUpper();
                if (!juzgado.StartsWith("JUZGADO")) juzgado = "JUZGADO DE " + juzgado;

                dict.Add("[JUZGADO]", juzgado);
            }
        }

        var data = await wordService.RenderAsync(@$"App_Data\Plantillas\{appSettings.Value.Cliente}\generador-documentos\{documento.FileName}", dict, tutelado);

        return new ArchivoViewModel()
        {
            Data = data,
            MimeType = documento.ContentType,
            FileName = $"{tutelado.Apellidos} {tutelado.Nombre} {documento.FileName}"
        };
    }
}