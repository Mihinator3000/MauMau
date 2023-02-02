using MauMau.Application.Dto.Identity;
using MauMau.Application.Requests.Identity;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MauMau.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDataDto loginData)
    {
        var request = new Login.Request(loginData);
        Login.Response response = await _mediator.Send(request);
        return Ok(response.AccessToken);
    }
}