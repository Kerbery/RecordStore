namespace RecordStore.Core.Entities.Models
{
    public class Condition : Entity
    {
        public string Name { get; set; }
        public ICollection<Record> Records { get; set; } = new List<Record>();
    }
}
