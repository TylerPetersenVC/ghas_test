using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().WithOrigins(
    "http://localhost:4200",
    "https://localhost:4200",
    "http://datingapptylerp",
    "https://datingapptylerp"
));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the app to listen on a specific port (e.g., 5000)
app.Urls.Add("http://localhost:5003");

app.Run();
