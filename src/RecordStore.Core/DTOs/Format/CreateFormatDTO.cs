using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Format
{
    public class CreateFormatDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Format")]
        public string Name { get; set; }
    }
}
