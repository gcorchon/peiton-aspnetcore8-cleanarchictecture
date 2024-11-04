namespace Peiton.Contracts.Usuarios;

public class UsuarioBloqueado
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string NombreCompleto { get; set; } = null!;
    public string Email { get; set; } = null!;
}