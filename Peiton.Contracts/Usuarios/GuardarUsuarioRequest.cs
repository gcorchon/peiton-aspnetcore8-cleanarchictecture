namespace Peiton.Contracts.Usuarios;

public class GuardarUsuarioRequest
{
    public string? Pwd { get; set; }
    public string Username { get; set; } = null!;
    public string Firma { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public Info? Info { get; set; }
    public string Email { get; set; } = null!;
    public bool Bloqueado { get; set; }
    public bool MostrarEnHome { get; set; }
    public string Imagen { get; set; } = null!;
    public string Cargo { get; set; } = null!;
    public string? TelefonoFijo { get; set; }
    public string? TelefonoMovil { get; set; }

    public IEnumerable<int> Permisos { get; set; } = null!;
    public IEnumerable<int> Grupos { get; set; } = null!;
}