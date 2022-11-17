namespace RecordStore.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTimeOffset CreateDate { get; set; }
    }
}