using MauMau.Application.Dto.Identity;
using MauMau.Application.Requests.Identity;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MauMau.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDataDto registerData)
    {
        var request = new Register.Request(registerData);
        Register.Response response = await _mediator.Send(request);
        return Ok(response.AccessToken);
    }
}