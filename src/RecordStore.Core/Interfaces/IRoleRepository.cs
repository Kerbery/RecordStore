namespace RecordStore.Core.Interfaces
{
    public interface IRoleRepository<T> : IRepository<T> where T: class
    {
        Task<IReadOnlyCollection<T>> GetUserRolesAsync(Guid id);
    }
}