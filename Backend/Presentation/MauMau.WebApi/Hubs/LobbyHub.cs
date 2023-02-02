using Microsoft.AspNetCore.SignalR;

namespace MauMau.WebApi.Hubs;

public class LobbyHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }


    public async Task Send(string message)
    {
        //Context.User
        await Clients.All.SendAsync("Send", message);
    }
}