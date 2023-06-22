using ChatServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatHubController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hubContext;

    public ChatHubController(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] Message model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.User, model.Message);

        return Ok();
    }
}
