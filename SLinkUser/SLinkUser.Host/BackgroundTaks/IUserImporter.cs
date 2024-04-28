namespace SLinkUser.Host.BackgroundTaks
{
    public interface IUserImporter
    {
        DateTime ExecutionDateTime { get; set; }
        Task ImportUsers();
        event Func<Task> OnChangeAsync;
    }
}