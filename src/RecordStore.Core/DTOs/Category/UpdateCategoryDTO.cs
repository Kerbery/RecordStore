using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Category")]
        public string Name { get; set; }
        public int Position { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
