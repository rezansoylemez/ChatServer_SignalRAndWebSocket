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
    private readonly ILogger<ChatHubController> _logger;
    public ChatHubController(IHubContext<ChatHub> hubContext, ILogger<ChatHubController> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] Message model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"Received Message - User: {model.User}, Message: {model.MessageBody}");

        Console.WriteLine($"Received Message - User: {model.User}, Message: {model.MessageBody}");
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.User, model.MessageBody);
        return Ok();

    }
}
