using RecordStore.Core.Resources;
using RecordStore.Core.ViewModels.Role;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.User
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = nameof(UILabels.Username), ResourceType = typeof(UILabels))]
        [Required(ErrorMessageResourceName = nameof(UILabels.FieldRequired), ErrorMessageResourceType = typeof(UILabels))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = nameof(UILabels.StringLengthRange), ErrorMessageResourceType = typeof(UILabels))]
        public string Username { get; set; }

        [Display(Name = nameof(UILabels.Email), ResourceType = typeof(UILabels))]
        [Required(ErrorMessageResourceName = nameof(UILabels.FieldRequired), ErrorMessageResourceType = typeof(UILabels))]
        [EmailAddress(ErrorMessageResourceName = nameof(UILabels.EmailInvalid), ErrorMessageResourceType = typeof(UILabels))]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(UILabels.NewPassword), ResourceType = typeof(UILabels))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = nameof(UILabels.StringLengthRange), ErrorMessageResourceType = typeof(UILabels))]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(UILabels.ConfirmPassword), ResourceType = typeof(UILabels))]
        [Compare(nameof(Password), ErrorMessageResourceName = nameof(UILabels.PasswordMismatch), ErrorMessageResourceType = typeof(UILabels))]
        public string? ConfirmPassword { get; set; }

        [Display(Name = nameof(UILabels.UserRoles), ResourceType = typeof(UILabels))]
        public IList<RoleViewModel> Roles { get; set; }
    }
}
