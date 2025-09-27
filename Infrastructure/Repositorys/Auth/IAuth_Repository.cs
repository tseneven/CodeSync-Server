using backend.Application.DTO;
using Microsoft.AspNetCore.Mvc;

public interface IAuth_Repository
{
    Task<string> Register(RegisterDTO registerDTO);
    Task<string> Login(RegisterDTO registerDTO);
}