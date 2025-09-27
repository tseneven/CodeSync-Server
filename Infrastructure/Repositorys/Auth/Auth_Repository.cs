using backend.Application.DTO;
using Backend.Core.Database;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Entities;
using Domain.GenerateSalt;
using Microsoft.AspNetCore.Mvc;
using backend.Infrastructure.Repositorys.Auth.Guards;
using API.Application.DTO;

namespace backend.Infrastructure.Repositorys.Auth
{
    public class Auth_Repository : IAuth_Repository
    {

        private readonly ApplicationContext _context;
        private readonly JWTService _jwtService;

        public Auth_Repository(ApplicationContext context, JWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string> Register(RegisterDTO registerDTO)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

            if (result == null)
            {
                var salt = PasswordHelper.GenerateSalt();
                var saltString = Convert.ToBase64String(salt);
                var hash_password = PasswordHelper.HashPassword(registerDTO.Password, salt);
                var hash_passwordString = Convert.ToBase64String(hash_password);
                User userDTO = new User()
                {
                    Email = registerDTO.Email,
                    Salt = saltString,
                    Hash_Password = hash_passwordString,
                    Login = registerDTO.Username,
                    Readme = ""
                };

                _context.Users.Add(userDTO);
                await _context.SaveChangesAsync();
                return "Запись создана";
            }
            return "Такая запись уже есть";

        }
        public async Task<AuthDTO> Login(RegisterDTO registerDTO)
        {
            var userEntity = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

            if (userEntity == null)
                return new AuthDTO{ Exeption = "Такого юзера нет" };

            var userDTO = new UserDTO
            {
                Id = userEntity.ID,
                Login = userEntity.Login,
                Email = userEntity.Email,
                PasswordHash = userEntity.Hash_Password,
                Salt = userEntity.Salt,
                Readme = userEntity.Readme
            };

            if (userDTO != null)
            {
                var saltBytes = Convert.FromBase64String(userDTO.Salt);
                var hashPassword = PasswordHelper.HashPassword(registerDTO.Password, saltBytes);
                var hash_passwordString = Convert.ToBase64String(hashPassword);

                if (userDTO.PasswordHash == hash_passwordString)
                {
                    var token = _jwtService.GenerateToken(userDTO.Id.ToString(), userDTO.Email);
                    return new AuthDTO { Token = token, UserID = userEntity.ID, Username = userEntity.Login };
                }
                return new AuthDTO { Exeption = "Пароль неверный" };
            }

            return new AuthDTO { Exeption = "Такого юзера нет" }; 
        }
    }
}
