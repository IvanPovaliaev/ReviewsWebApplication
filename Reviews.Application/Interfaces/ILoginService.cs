using Reviews.Application.Models;
using Reviews.Domain.Models;

namespace Reviews.Application.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Add a new login to db
        /// </summary>
        /// <param name="newLogin">LoginDTO model</param>
        /// <returns>Login model, if iy was added successfully; otherwise null</returns>
        Task<Login?> AddLoginAsync(LoginDTO newLogin);

        /// <summary>
        /// Check login 
        /// </summary>
        /// <param name="login">LoginDTO model</param>
        /// <returns>True, if the login model is valid; otherwise false</returns>
        Task<bool> CheckLoginAsync(LoginDTO login);
    }
}
