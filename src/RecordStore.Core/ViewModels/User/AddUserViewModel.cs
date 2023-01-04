using RecordStore.Core.Resources;
using RecordStore.Core.ViewModels.Role;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.User
{
    public class AddUserViewModel
    {
        [Display(Name = nameof(UILabels.Username))]
        [Required(ErrorMessage = nameof(UILabels.FieldRequired))]
        [StringLength(100, MinimumLength = 3, ErrorMessage = nameof(UILabels.StringLengthRange))]
        public string Username { get; set; }

        [Display(Name = nameof(UILabels.Email))]
        [Required(ErrorMessage = nameof(UILabels.FieldRequired))]
        [EmailAddress(ErrorMessage = nameof(UILabels.EmailInvalid))]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(UILabels.Password))]
        [Required(ErrorMessage = nameof(UILabels.FieldRequired))]
        [StringLength(100, MinimumLength = 6, ErrorMessage = nameof(UILabels.StringLengthRange))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(UILabels.ConfirmPassword))]
        [Required(ErrorMessage = nameof(UILabels.FieldRequired))]
        [Compare(nameof(Password), ErrorMessage = nameof(UILabels.PasswordMismatch))]
        public string ConfirmPassword { get; set; }

        [Display(Name = nameof(UILabels.UserRoles))]
        public IList<RoleViewModel> Roles { get; set; }
    }
}
