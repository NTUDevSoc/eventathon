namespace DevSoc.Eventathon.Data.Security;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Authenticate(string username, string password);
}