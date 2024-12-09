using Microsoft.EntityFrameworkCore;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using Reviews.Domain;
using Reviews.Domain.Models;

namespace Reviews.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataBaseContext _databaseContext;
        private readonly IHashService _hashService;

        public LoginService(DataBaseContext databaseContext, IHashService hashService)
        {
            _databaseContext = databaseContext;
            _hashService = hashService;
        }

        public async Task<Login?> AddLoginAsync(LoginDTO newLogin)
        {
            var loginDB = await _databaseContext.Logins
                                                .FirstOrDefaultAsync(l => l.UserName == newLogin.UserName);

            if (loginDB is not null && !string.IsNullOrEmpty(newLogin.Password))
            {
                return null;
            }

            var hashedPassword = _hashService.GenerateHash(newLogin.Password!);
            var newLoginDb = new Login
            {
                UserName = newLogin.UserName,
                Password = hashedPassword
            };

            await _databaseContext.AddAsync(newLoginDb);
            var result = await _databaseContext.SaveChangesAsync();
            return result > 0 ? newLoginDb : null;
        }


        public async Task<bool> CheckLoginAsync(LoginDTO login)
        {
            var loginDB = await _databaseContext.Logins
                                                .FirstOrDefaultAsync(l => l.UserName == login.UserName);

            return _hashService.IsEquals(login.Password, loginDB.Password);
        }
    }
}
