namespace Peiton.Contracts.Inmuebles;

public class TuteladoAvisoInmueble
{
    public string NombreCompleto { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public string Nombramiento { get; set; } = null!; //

    public IEnumerable<SeguroHogar> SegurosHogar { get; set; } = new List<SeguroHogar>(); //
}



