using API.Application.DTO;
using backend.Application.DTO;
using Microsoft.AspNetCore.Mvc;

public interface IAuth_Repository
{
    Task<string> Register(RegisterDTO registerDTO);
    Task<AuthDTO> Login(RegisterDTO registerDTO);
}