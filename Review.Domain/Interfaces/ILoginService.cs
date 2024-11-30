using Review.Domain.Models;

namespace Review.Domain.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Проверить логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>True, если логин валидный; иначе - false</returns>
        bool CheckLogin(Login login);
    }
}
