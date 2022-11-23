using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Artist
{
    public class CreateArtistDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Artist")]
        public string Name { get; set; }

        [StringLength(256, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Description { get; set; }
    }
}
