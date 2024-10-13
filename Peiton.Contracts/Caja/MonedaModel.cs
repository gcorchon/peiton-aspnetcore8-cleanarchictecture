using System.Xml.Serialization;

namespace Peiton.Contracts.Caja;

public class MonedaModel
{
    [XmlAttribute("valor")]
    public decimal Valor { get; set; }

    [XmlAttribute("reserva")]
    public int Reserva { get; set; }

    [XmlAttribute("corriente")]
    public int Corriente { get; set; }
}