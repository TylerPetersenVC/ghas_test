using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().WithOrigins("http://localhost:4200", "https://localhost:4200", "http://datingapptylerp", "https://datingapptylerp"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
