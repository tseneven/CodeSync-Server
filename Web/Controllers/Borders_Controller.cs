using API.Application.DTO;
using API.Infrastructure.Repositorys.Board;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BordersController : ControllerBase
    {
        private readonly IBoard_Repository _boradRepository;

        public BordersController(IBoard_Repository boradRepository)
        {
            _boradRepository = boradRepository;
        }



        [Authorize]
        [HttpPost("CreateBorder")]
        public async Task<IActionResult> CreateBorder([FromBody] BoardDTO boradDTO)
        {
            string result = await _boradRepository.CreateBorder(boradDTO);
            Console.WriteLine(result);

            if (result == "Запись создана") {
                return Ok();
            }
            else return BadRequest(result);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _boradRepository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
