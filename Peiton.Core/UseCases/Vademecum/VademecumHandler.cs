
using ClosedXML.Excel;
using Peiton.Contracts.Common;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Vademecum;

[Injectable]
public class VademecumHandler(IVademecumRepository vademecumRepository)
{
    public async Task<ArchivoViewModel> HandleAsync(DateTime fecha)
    {
        var entity = await vademecumRepository.GetAsync(v => v.Fecha.Date == fecha.Date) ?? throw new NotFoundException("Vademecum no disponible en la fecha indicada");

        var vademecum = VademecumData.FromData(entity.Datos);

        using var workbook = new XLWorkbook();
        // Crear una hoja de Excel
        var worksheet = workbook.Worksheets.Add("Apoyos Prestados");

        // Especificar la fecha
        worksheet.Cell("B1").Value = fecha.ToString("dd.MM.yyyy");

        // Títulos de las secciones
        worksheet.Cell("B2").Value = "APOYOS PRESTADOS";

        // Formato de celdas
        var titleRange = worksheet.Range("B2:G2");
        titleRange.Merge().Style.Font.Bold = true;
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        titleRange.Style.Fill.BackgroundColor = XLColor.LightBlue;


        worksheet.Cell("B2").Value = "APOYOS PRESTADOS";

        worksheet.Cell("A3").Value = "8.1";
        worksheet.Cell("B3").Value = "Apoyos prestados en el año anterior";
        worksheet.Cell("C3").Value = "TOTAL";
        worksheet.Range($"D3:G3").Merge();

        var cargos = vademecum.Apoyos;
        worksheet.Cell("A4").Value = "8.2";
        worksheet.Cell("B4").Value = "Apoyos prestados en el año en curso";
        worksheet.Cell("C4").Value = cargos.Sum(c => c.Total);

        var cargoIndex = 4;
        foreach (var cargo in cargos)
        {
            worksheet.Cell($"D{cargoIndex}").Value = cargo.Descripcion;

            worksheet.Cell($"G{cargoIndex}").Value = cargo.Total;
            worksheet.Range($"D{cargoIndex}:F{cargoIndex}").Merge();
            cargoIndex++;
        }

        worksheet.Range($"A4:A{cargoIndex - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"B4:B{cargoIndex - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"C4:C{cargoIndex - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


        worksheet.Cell($"A{cargoIndex}").Value = "8.3";
        worksheet.Cell($"B{cargoIndex}").Value = "Nuevos cargos judiciales en el año en curso";
        worksheet.Cell($"C{cargoIndex}").Value = vademecum.TotalCargosJudicialesAnoEnCurso.ToString();
        worksheet.Cell($"D{cargoIndex}").Value = "Designación por los juzgados";
        worksheet.Range($"D{cargoIndex}:F{cargoIndex}").Merge();

        cargoIndex++;

        var distribucionPorSexos = vademecum.Sexos;

        var total = distribucionPorSexos.Sum(d => d.Total);
        var hombres = distribucionPorSexos.First(d => d.Descripcion == "H").Total;
        var mujeres = distribucionPorSexos.First(d => d.Descripcion == "M").Total;

        var distribucionPorEstadoCivil = vademecum.EstadosCiviles.ToArray();

        //El diseño del Excel que me han pasado es una mierda, los datos de estados civilies aparece a la derecha de los sexos, pero no tienen nada que ver

        var totalEstadoCivil = distribucionPorEstadoCivil.Sum(d => d.Total);
        var estadosCivilesParaHombres = Convert.ToInt32(Math.Ceiling(distribucionPorEstadoCivil.Length / 2.0));
        var estadosCivilesParaMujeres = distribucionPorEstadoCivil.Length - estadosCivilesParaHombres;

        worksheet.Cell($"A{cargoIndex}").Value = "8.4";
        worksheet.Cell($"B{cargoIndex}").Value = "Características de las personas apoyadas en el año en curso";
        worksheet.Range($"A{cargoIndex}:A{cargoIndex + distribucionPorEstadoCivil.Length - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"B{cargoIndex}:B{cargoIndex + distribucionPorEstadoCivil.Length - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"C{cargoIndex}:C{cargoIndex + distribucionPorEstadoCivil.Length - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

        worksheet.Cell($"D{cargoIndex}").Value = "Hombres";
        worksheet.Cell($"E{cargoIndex}").Value = (hombres * 100.0 / total).ToString("N2") + "%";
        worksheet.Range($"D{cargoIndex}:D{cargoIndex + estadosCivilesParaHombres - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"E{cargoIndex}:E{cargoIndex + estadosCivilesParaHombres - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

        worksheet.Cell($"D{cargoIndex + estadosCivilesParaHombres}").Value = "Mujeres";
        worksheet.Cell($"E{cargoIndex + estadosCivilesParaHombres}").Value = (mujeres * 100.0 / total).ToString("N2") + "%";
        worksheet.Range($"D{cargoIndex + estadosCivilesParaHombres}:D{cargoIndex + estadosCivilesParaHombres + estadosCivilesParaMujeres - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Range($"E{cargoIndex + estadosCivilesParaHombres}:E{cargoIndex + estadosCivilesParaHombres + estadosCivilesParaMujeres - 1}").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

        for (var i = 0; i < distribucionPorEstadoCivil.Length; i++)
        {
            worksheet.Cell($"F{cargoIndex}").Value = distribucionPorEstadoCivil[i].Descripcion;
            worksheet.Cell($"G{cargoIndex}").Value = (distribucionPorEstadoCivil[i].Total * 100.0 / totalEstadoCivil).ToString("N2") + "%";
            cargoIndex += 1;
        }

        worksheet.Cell($"A{cargoIndex}").Value = "8.5";
        worksheet.Cell($"B{cargoIndex}").Value = "Personas curateladas en centros residenciales";
        worksheet.Cell($"C{cargoIndex}").Value = vademecum.TotalPersonasCurateladasCentrosResidenciales.ToString();
        worksheet.Range($"D{cargoIndex}:G{cargoIndex}").Merge();

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.6";
        worksheet.Cell($"B{cargoIndex}").Value = $"Rendiciones de cuentas {fecha.Year - 1} presentadas";
        worksheet.Cell($"C{cargoIndex}").Value = vademecum.TotalRendicionesPresentadasAnoAnterior.ToString();
        worksheet.Range($"D{cargoIndex}:G{cargoIndex}").Merge();
        worksheet.Range($"B2:G{cargoIndex}").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

        cargoIndex += 3;

        worksheet.Range($"A{cargoIndex}:F{cargoIndex + 6}").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
        worksheet.Range($"A{cargoIndex}:F{cargoIndex + 6}").Style.Border.SetInsideBorder(XLBorderStyleValues.None);
        worksheet.Cell($"B{cargoIndex}").Value = "ORIGEN DE LOS DATOS";
        worksheet.Cell($"B{cargoIndex}").Style.Font.SetBold();

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.1";
        worksheet.Cell($"B{cargoIndex}").Value = "Memoria de actividad 2023";

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.2";
        worksheet.Cell($"B{cargoIndex}").Value = "Consulta 213 aplicación informática de AMAPAD";

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.3";
        worksheet.Cell($"B{cargoIndex}").Value = "Consulta 234 aplicación informática de AMAPAD";

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.4";
        worksheet.Cell($"B{cargoIndex}").Value = "Consulta 28 y 96 aplicación informática AMAPAD";

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.5";
        worksheet.Cell($"B{cargoIndex}").Value = "Consulta 53 aplicación informática AMAPAD";

        cargoIndex++;

        worksheet.Cell($"A{cargoIndex}").Value = "8.6";
        worksheet.Cell($"B{cargoIndex}").Value = "Consulta 41 aplicación informática AMAPAD";

        worksheet.Columns().AdjustToContents();
        // Guardar el libro de Excel
        var ms = new MemoryStream();

        workbook.SaveAs(ms);

        return new ArchivoViewModel()
        {
            Data = ms.ToArray(),
            MimeType = MimeTypeHelper.Excel,
            FileName = $"Vademecum {fecha: dd-MM-yyyy}.xlsx"
        };
    }
}