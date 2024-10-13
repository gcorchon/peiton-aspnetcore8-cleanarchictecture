using System.Xml.Serialization;

namespace Peiton.Contracts.Caja;

public class ArqueoModel
{
    [XmlElement("saldoCajaAMTA")]
    public decimal? SaldoCajaAMTA { get; set; }

    [XmlElement("saldoCajaTutelados")]
    public decimal? SaldoCajaTutelados { get; set; }

    [XmlArray("monedas")]
    [XmlArrayItem("moneda", typeof(MonedaModel))]
    public MonedaModel[] Monedas { get; set; } = [];
}