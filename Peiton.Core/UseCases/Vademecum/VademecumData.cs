using System.Xml.Linq;
using Peiton.Contracts.Vademecum;

namespace Peiton.Core.UseCases.Vademecum;
public class VademecumData
{
    public IEnumerable<VademecumTotal> Apoyos { get; private set; } = [];
    public IEnumerable<VademecumTotal> Sexos { get; private set; } = [];
    public IEnumerable<VademecumTotal> EstadosCiviles { get; private set; } = [];
    public int TotalCargosJudicialesAnoEnCurso { get; private set; }
    public int TotalPersonasCurateladasCentrosResidenciales { get; private set; }
    public int TotalRendicionesPresentadasAnoAnterior { get; private set; }

    public static VademecumData FromData(string xml)
    {
        var data = new VademecumData();
        var doc = XDocument.Parse(xml);
        var root = doc.Document!.Root!;
        
        data.Apoyos = root.Element("Apoyos")!.Elements("Apoyo").Select(node => new VademecumTotal()
        {
            Descripcion = node.Element("Descripcion")!.Value,
            Total = Convert.ToInt32(node.Element("Total")!.Value)
        });
        
        data.Sexos = root.Element("Sexos")!.Elements("Sexo").Select(node => new VademecumTotal()
        {
            Descripcion = node.Element("Descripcion")!.Value,
            Total = Convert.ToInt32(node.Element("Total")!.Value)
        });

        data.EstadosCiviles = root.Element("EstadosCiviles")!.Elements("EstadoCivil").Select(node => new VademecumTotal()
        {
            Descripcion = node.Element("Descripcion")!.Value,
            Total = Convert.ToInt32(node.Element("Total")!.Value)
        });

        data.TotalCargosJudicialesAnoEnCurso = Convert.ToInt32(root.Element("TotalCargosJudicialesAnoEnCurso")!.Value);
        data.TotalPersonasCurateladasCentrosResidenciales = Convert.ToInt32(root.Element("TotalPersonasCurateladasCentrosResidenciales")!.Value);
        data.TotalRendicionesPresentadasAnoAnterior = Convert.ToInt32(root.Element("TotalRendicionesPresentadasAnoAnterior")!.Value);

        return data;
    }
}