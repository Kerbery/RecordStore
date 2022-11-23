namespace RecordStore.Core.DTOs.Category
{
    public class GetCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public GetCategoryDTO? ParentCategory { get; set; }
    }
}
