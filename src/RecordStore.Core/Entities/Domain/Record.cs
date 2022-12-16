namespace RecordStore.Core.Entities.Models
{
    public class Record : Entity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public Guid? FormatId { get; set; }
        public Format? Format { get; set; }
        public Guid? ReleaseId { get; set; }
        public Release? Release { get; set; }
        public Guid? RecordConditionId { get; set; }
        public Condition? RecordCondition { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Style> Styles { get; set; } = new List<Style>();
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
