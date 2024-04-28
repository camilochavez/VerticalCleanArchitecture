using Microsoft.AspNetCore.SignalR;
using SLinkUser.Host.Hub;

namespace SLinkUser.Host.BackgroundTaks
{
    public class UserImportRunningWorker : BackgroundService, IDisposable
    {
        private readonly IUserImporter _userImporter;
        private readonly IHubContext<MessagingUserImportHub, IUserImportCommand> _messagingHub;
        private Timer? _timer;
        private const int delayExecutionTime = 10;

        public UserImportRunningWorker(IUserImporter userImporter,
                                       IHubContext<MessagingUserImportHub, IUserImportCommand> messagingHub)
        {
            _userImporter = userImporter ?? throw new ArgumentNullException(nameof(userImporter));
            _messagingHub = messagingHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(TriggerUserImportAsync, null, TimeSpan.Zero, TimeSpan.FromMinutes(delayExecutionTime));
            await Task.CompletedTask;
        }

        private async void TriggerUserImportAsync(object? state)
        {
            await _userImporter.ImportUsers();
            await _messagingHub.Clients.All.NotifyUserImportAsync(DateTime.Now);
        }

        public new void Dispose()
        {
            _timer?.Dispose();
        }
    }
}