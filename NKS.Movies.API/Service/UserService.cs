namespace NKS.Movies.API.Service
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("me") && password.Equals("Pa$$WoRd");
        }
    }
}
