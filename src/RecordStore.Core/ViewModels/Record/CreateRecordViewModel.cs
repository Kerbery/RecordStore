using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
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

        [MaxLength(256, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string? Description { get; set; }
        public CreateFormatDTO? Format { get; set; }
        public CreateReleaseDTO? Release { get; set; }
        public CreateConditionDTO? RecordCondition { get; set; }
        public ICollection<CreateCategoryDTO>? Categories { get; set; }
        //public ICollection<CreateArtistDTO> Artists { get; set; }
        public ICollection<CreateGenreDTO>? Genres { get; set; }
        public ICollection<CreateStyleDTO>? Styles { get; set; }
        //public ICollection<Photo> Photos { get; set; }
    }
}
