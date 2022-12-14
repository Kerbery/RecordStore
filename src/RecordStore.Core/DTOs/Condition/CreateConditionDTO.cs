using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.DTOs.Condition
{
    public class CreateConditionDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Condition")]
        public string Name { get; set; }
    }
}
