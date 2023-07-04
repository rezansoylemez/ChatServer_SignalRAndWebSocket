using ChatServer.Models;
using ChatServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.IO;
using System.Runtime.InteropServices;

namespace ChatServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatHubController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly ILogger<ChatHubController> _logger;
    private readonly ILogRepository _logRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;
    public ChatHubController(IHubContext<ChatHub> hubContext, ILogger<ChatHubController> logger, ILogRepository logRepository,IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _hubContext = hubContext;
        _logger = logger;
        _logRepository = logRepository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
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

        var user = await _userRepository.GetAsync(a => a.Id == model.UserId);


        ReadLogsFromFileAndWriteToConsole(logFilePath);
        _logger.LogInformation($"Received Message - UserFirstName: {user.FirstName},UserLastName: {user.LastName}, Message: {model.Body}");

        Console.WriteLine($"Received Message - UserFirstName: {user.FirstName},UserLastName: {user.LastName}, Message: {model.Body}");

        await _hubContext.Clients.All.SendAsync($"Received Message - UserFirstName: {user.FirstName},UserLastName: {user.LastName}, Message: {model.Body}");

        var createdMessage = await _messageRepository.AddAsync(model);

        //User user = new User()
        //{
        //    FirstName = model.UserFirstName, 
        //    LastName = model.UserLastName
        //};
        //var createdUser = await _userRepository.AddAsync(user);

        Log log = new Log()
        {
            MessageId = createdMessage.Id
        };
        var createdLog = await _logRepository.AddAsync(log);

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
