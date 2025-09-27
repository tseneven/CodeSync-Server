using backend.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth_Repository _authRepository;

        public AuthController(IAuth_Repository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                var token = await _authRepository.Login(registerDTO);

                if (token.Token == "Такого юзера нет")
                {
                    return NotFound(token);
                }
                if (token.Token == "Пароль неверный")
                {
                    return StatusCode(403, token);
                }
                else return Ok(token);

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                var result = await _authRepository.Register(registerDTO);
                if (result == "Такая запись уже есть") return BadRequest(result);
                else return Ok(result);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
