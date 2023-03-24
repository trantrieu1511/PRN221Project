using Microsoft.AspNetCore.SignalR;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly PRN221_Project_QLNSContext dbContext;

        public NotificationHub(PRN221_Project_QLNSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task SendNotificationToAll(string message)
        {
            await Clients.All.SendAsync("ReceivedNotification", message);
        }

        public async System.Threading.Tasks.Task SendNotificationToClient(string message, string username)
        {
            var hubConnections = dbContext.HubConnections.Where(con => con.Username == username).ToList();

            foreach (var hubConnection in hubConnections)
            {
                await Clients.Client(hubConnection.ConnectionId).SendAsync("ReceivedPersonalNotification", message, username);
            }
        }
        public async System.Threading.Tasks.Task SendNotificationToGroup(string message, List<string> username)
        {


        }
        public static int notificationCounter = 0;
        public static List<string> messages = new();

        public async System.Threading.Tasks.Task SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                notificationCounter++;
                messages.Add(message);
                await LoadMessages();
            }
        }

        public async System.Threading.Tasks.Task LoadMessages()
        {
            await Clients.All.SendAsync("LoadNotification", messages, notificationCounter);
        }

        public override System.Threading.Tasks.Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnected");
            return base.OnConnectedAsync();
        }

        public async System.Threading.Tasks.Task SaveUserConnection(string username)
        {
            using (PRN221_Project_QLNSContext context = new PRN221_Project_QLNSContext())
            {
                var connectionId = Context.ConnectionId;
                if (username != context.Accounts.FirstOrDefault(a => a.Isadmin || a.Ismanager).Username)
                {
                    HubConnection hubConnection = new HubConnection
                    {
                        ConnectionId = connectionId,
                        Username = username
                    };

                    dbContext.HubConnections.Add(hubConnection);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        //public override System.Threading.Tasks.Task OnDisconnectedAsync(Exception? exception)
        //{

        //    var hubConnection = dbContext.HubConnections.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId);
        //    if (hubConnection != null)
        //    {
        //        dbContext.HubConnections.Remove(hubConnection);
        //        dbContext.SaveChangesAsync();
        //    }

        //    return base.OnDisconnectedAsync(exception);
        //}
    }
}

