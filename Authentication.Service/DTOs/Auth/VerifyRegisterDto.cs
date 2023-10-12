namespace Authentication.Service.DTOs.Auth;

public class VerifyRegisterDto
{
    public string Email { get; set; } = String.Empty;

    public int Code { get; set; }
}
