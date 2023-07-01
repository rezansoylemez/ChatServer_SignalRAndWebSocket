using Serilog;
using Serilog.Debugging;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Console Log 
//Log.Logger = new LoggerConfiguration()
//       .MinimumLevel.Information()
//       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//       .Enrich.FromLogContext()
//       .WriteTo.Console()
//       .CreateLogger();

// .txt Log
string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string logFilePath = Path.Combine(desktopPath, "ChatServer","SeriLog","log.txt");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logFilePath)
    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddControllers();

// SeriLog Configuration
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog(dispose: true);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseWebSockets();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chathub");
});


app.Run();
