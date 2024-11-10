namespace Peiton.Contracts.Usuarios;

public class UsuarioPermisoEmail
{
    public string Email { get; set; } = null!;
    public bool RecibirMensajes { get; set; }
    public bool RecibirMensajesHeredado { get; set; }
}