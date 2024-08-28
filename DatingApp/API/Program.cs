using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline
app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins(
        "http://localhost:4200",
        "https://localhost:4200",
        "http://datingapptylerp",
        "https://datingapptylerp",
        "http://datingapptylerpapi",
        "https://datingapptylerpapi"
    )
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the app to listen on a specific port (e.g., 5000)
// app.Urls.Add("http://localhost:5003");

app.Run();
