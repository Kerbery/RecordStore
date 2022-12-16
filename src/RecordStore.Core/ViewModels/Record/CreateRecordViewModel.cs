using RecordStore.Core.ViewModels.Category;
using RecordStore.Core.ViewModels.Genre;
using RecordStore.Core.ViewModels.Style;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.Record
{
    public class CreateRecordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Record Title")]
        public string Title { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }

        [MaxLength(256, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string? Description { get; set; }

        [Display(Name = "Format")]
        public Guid? FormatId { get; set; }

        [Display(Name = "Release")]
        public Guid? ReleaseId { get; set; }

        [Display(Name = "Record Condition")]
        public Guid? RecordConditionId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        //public IEnumerable<Guid> Artists { get; set; } = new List<Guid>();
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
        public List<StyleViewModel> Styles { get; set; } = new List<StyleViewModel>();
        public List<string> Photos { get; set; } = new List<string>();
    }
}
