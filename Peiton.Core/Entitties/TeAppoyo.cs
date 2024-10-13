namespace Peiton.Core.Entities;
public class TeAppoyo
{
	public int TuteladoId { get; set; }
	public string Username { get; set; } = null!;
	public string Password { get; set; } = null!;
	public bool Enabled { get; set; }
	public DateTime? LastLogin { get; set; }
	public string? RefreshToken { get; set; }
	public DateTime? RefreshTokenExpirationDate { get; set; }
	public string? WebPushInfo { get; set; }
	public bool PasswordChange { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
