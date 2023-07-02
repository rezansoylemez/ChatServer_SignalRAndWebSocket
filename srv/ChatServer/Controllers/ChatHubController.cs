using ChatServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.IO;

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
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string logFilePath = Path.Combine(desktopPath, "ChatServer", "SeriLog", "log.txt");

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        ReadLogsFromFileAndWriteToConsole(logFilePath);
        _logger.LogInformation($"Received Message - User: {model.User}, Message: {model.MessageBody}");

        Console.WriteLine($"Received Message - User: {model.User}, Message: {model.MessageBody}");
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.User, model.MessageBody);


        return Ok();

    }


    // Log dosyasını okuyarak logları Console'a yazdıran bir metot
    static void ReadLogsFromFileAndWriteToConsole(string filePath)
    {
        //File(filePath);
        //if (filePath.DefaultIfEmpty())
        //{
        //    string[] logLines = File.ReadAllLines(filePath);

        //    foreach (string logLine in logLines)
        //    {
        //        Console.WriteLine(logLine);
        //    }
        //}
    }
}
