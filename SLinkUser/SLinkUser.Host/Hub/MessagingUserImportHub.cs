using Microsoft.AspNetCore.SignalR;

namespace SLinkUser.Host.Hub
{
    public interface IUserImportCommand
    {
        Task NotifyUserImportAsync(DateTime syncTriggeredOn);
    }

    public class MessagingUserImportHub : Hub<IUserImportCommand>
    {
        public async Task NotifyUserImportAsync(DateTime dateTime)
        {
            await Clients.All.NotifyUserImportAsync(dateTime);
        }
    }
}
