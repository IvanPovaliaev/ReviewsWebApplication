using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using Reviews.Domain;

namespace Reviews.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataBaseContext _databaseContext;

        public LoginService(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CheckLogin(LoginDTO login)
        {
            var loginDB = _databaseContext.Logins
                                          .FirstOrDefault(l => l.UserName == login.UserName);

            return loginDB?.Password!.Equals(login.Password) ?? false;
        }
    }
}
