namespace FTS.Service.DTOs;

public class UserResultDto
{
    public long Id { get; }
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Address { get; } = string.Empty;
}
