using MauMau.Application.Extensions;
using MauMau.DataAccess;
using MauMau.DataAccess.Extensions;
using MauMau.WebApi.Hubs;
using MauMau.WebApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", b => b
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("http://localhost:3000")
));

builder.Services.AddDatabaseContext(o => o
    .UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath = new PathString("/Account/Login");
        o.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddSignalR()
    .AddHubOptions<LobbyHub>(o => o.AddFilter<AuthFilter>());

builder.Services.AddApplicationServices();

builder.Services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<LobbyHub>("/lobby");

app.MapControllers();

var scope = app.Services.CreateAsyncScope();
var context = scope.ServiceProvider.GetRequiredService<MauMauDbContext>();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await scope.ServiceProvider.ConfigureDefaultRoles();

app.Run();