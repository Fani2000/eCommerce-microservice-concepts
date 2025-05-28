namespace eCommerce.Core.DTO;

public record LoginRequest(
    string? Email,
    string? Password)
{
    public LoginRequest():this(default,default) { }
}