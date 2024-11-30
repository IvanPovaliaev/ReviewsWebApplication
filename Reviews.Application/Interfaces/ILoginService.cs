using Reviews.Application.Models;

namespace Reviews.Application.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Проверить логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>True, если логин валидный; иначе - false</returns>
        bool CheckLogin(LoginDTO login);
    }
}
