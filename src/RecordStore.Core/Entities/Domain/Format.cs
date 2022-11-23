namespace RecordStore.Core.Entities.Models
{
    public class Format : Entity
    {
        public string Name { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
