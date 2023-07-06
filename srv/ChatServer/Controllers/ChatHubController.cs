using ChatServer.Context;
using ChatServer.Models;
using ChatServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
            ChatLobbyId = 2
        };
        var createdLog = await _logRepository.AddAsync(log);

        return Ok();

    }
    public async void SendMessage(int userId, int chatLobbyId, string content)
    {
        var user = await _userRepository.GetAsync(a => a.Id == userId);

        //using (var dbContext = new  BaseDbContext())
        //{
        //    var chatLobby = dbContext.ChatLobbies
        //        .Include(cl => cl.ChatLobbyUsers)
        //        .ThenInclude(clu => clu.User)
        //        .FirstOrDefault(cl => cl.Id == chatLobbyId);
             
        //    if (user != null && chatLobby != null)
        //    {
        //        // Mesajı oluşturun ve kaydedin
        //        var message = new Message
        //        {
        //            ChatLobby = chatLobby,
        //            User = user,
        //            Content = content
        //        };

        //        dbContext.Messages.Add(message);
        //        dbContext.SaveChanges();

        //        // Mesajı loglayın
        //        var log = new Log
        //        {
        //            ChatLobby = chatLobby,
        //            User = user,
        //            Message = message
        //        };

        //        dbContext.Logs.Add(log);
        //        dbContext.SaveChanges();

        //        Console.WriteLine($"Mesaj gönderildi - User: {user.FirstName} {user.LastName}, ChatLobbyId: {chatLobby.Id}, İçerik: {content}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Kullanıcı veya chat lobi bulunamadı.");
        //    }
        //}
    }


}
