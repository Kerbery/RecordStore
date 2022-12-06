using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.Record
{
    public class EditRecordViewModel
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
        public Guid FormatId { get; set; }

        [Display(Name = "Release")]
        public Guid ReleaseId { get; set; }

        [Display(Name = "Record Condition")]
        public Guid RecordConditionId { get; set; }
        public IEnumerable<Guid>? Categories { get; set; }
        //public IEnumerable<Guid> Artists { get; set; }
        public IEnumerable<Guid>? Genres { get; set; }
        public IEnumerable<Guid>? Styles { get; set; }
    }
}
