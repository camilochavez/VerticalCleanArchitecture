using SLinkUser.Host.Services;

namespace SLinkUser.Host.BackgroundTaks
{
    public class UserImporter(UserClientService userClientService) : IUserImporter
    {
        public DateTime ExecutionDateTime { get; set; }
        public async Task ImportUsers()
        {
            await userClientService.ImportUsers();
            ExecutionDateTime = DateTime.UtcNow;
            //OnChangeAsync?.Invoke();
        }

        public event Func<Task> OnChangeAsync;
    }
}