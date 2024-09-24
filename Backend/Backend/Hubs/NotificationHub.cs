using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly AppDbContext _context;

        public NotificationHub(AppDbContext context)
        { 
            _context = context;
        }

        public async Task AskServer(string textFromClient)
        {
            string temp = "";
            if (textFromClient == "hey")
            {
                temp = "message way hey";
            }
            else
            {
                temp = "message was something else";
            }

            await Clients.Clients(Context.ConnectionId).SendAsync("AskServerResponse", temp);
        }

        private async Task ProcessAuth(string userid)
        {
            string signarRId = Context.ConnectionId;
            var userConn = await _context.UserConnections.SingleOrDefaultAsync(x => x.UserId == userid);
            if (userConn == null)
            {
                UserConnection conn = new UserConnection()
                {
                    UserId = userid,
                    ConnectionId = signarRId
                };
                _context.UserConnections.Add(conn);
            }
            else
            {
                userConn.ConnectionId = signarRId;
            }
            await _context.SaveChangesAsync();
        }

        public async Task AuthUser(string userid)
        {
            await ProcessAuth(userid);

            var user = await _context.UserConnections.SingleOrDefaultAsync(x => x.UserId == userid);

            await Clients.Caller.SendAsync("AuthUserResponse", user);
        }

        public async Task ReAuthUser(string userid)
        {
            await ProcessAuth(userid);

            var user = await _context.UserConnections.SingleOrDefaultAsync(x => x.UserId == userid);

            await Clients.Caller.SendAsync("ReAuthUserResponse", user);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
