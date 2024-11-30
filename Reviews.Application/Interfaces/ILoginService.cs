using Reviews.Application.Models;

namespace Reviews.Application.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Check login 
        /// </summary>
        /// <param name="login">LoginDTO model</param>
        /// <returns>True, if the login model is valid; otherwise false</returns>
        bool CheckLogin(LoginDTO login);
    }
}
