using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using Reviews.Domain;

namespace Reviews.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataBaseContext databaseContext;

        public LoginService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public bool CheckLogin(LoginDTO login)
        {
            var containsLogin = databaseContext.Logins;

            foreach (var item in containsLogin)
            {
                if (item.UserName.Equals(login.UserName) && item.Password.Equals(login.Password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
