namespace RecordStore.Core.ViewModels.User
{
    public class GetUserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsLockedout { get; set; }
    }
}
