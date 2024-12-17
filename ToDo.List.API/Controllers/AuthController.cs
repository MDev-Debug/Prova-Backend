using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.List.Domain.DTOs;
using ToDo.List.Domain.Interfaces;

namespace ToDo.List.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] AccountRequestDTO account)
    {
        var result = await _accountService.CriarConta(account);

        if (result == "")
            return BadRequest();

        return Ok(new { token = result});
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
    {
        var result = await _accountService.Login(request);
        if (result == "")
            return BadRequest();

        return Ok(new { token = result });
    }
}