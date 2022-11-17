namespace RecordStore.Core.Entities.Models
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
