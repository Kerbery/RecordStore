using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Release
{
    public class UpdateReleaseDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Release")]
        public string Name { get; set; }
    }
}
