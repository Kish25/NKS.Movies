namespace NKS.Movies.API.Service
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);

    }
}