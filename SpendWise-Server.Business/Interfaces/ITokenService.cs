namespace SpendWise_Server.Repos.Interfaces;

public interface ITokenService
{
    string CreateToken(string username);
    int DecodeJWT (string jwt);
}