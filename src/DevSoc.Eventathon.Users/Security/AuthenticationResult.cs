namespace DevSoc.Eventathon.Data.Security;

public class AuthenticationResult
{
    public bool IsSuccess { get; set; }
    public string? Jwt { get; set; }

    public static AuthenticationResult Success(string jwt)
    {
        return new AuthenticationResult
        {
            Jwt = jwt,
            IsSuccess = true
        };
    }

    public static AuthenticationResult Failed()
    {
        return new AuthenticationResult
        {
            Jwt = null,
            IsSuccess = false
        };
    }
}