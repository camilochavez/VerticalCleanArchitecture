namespace SLinkUser.Host.Model
{
    public record UserUpdateRequest(int Id, string UserName);

    public class UserToUpdate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
    }
}
