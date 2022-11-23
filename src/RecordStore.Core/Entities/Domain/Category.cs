namespace RecordStore.Core.Entities.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
