using RecordStore.Core.Resources;
using RecordStore.Core.ViewModels.Category;
using RecordStore.Core.ViewModels.Genre;
using RecordStore.Core.ViewModels.Style;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.Record
{
    public class EditRecordViewModel
    {
        [Display(Name = nameof(UILabels.Record_Title))]
        [Required(ErrorMessage = nameof(UILabels.FieldRequired))]
        [StringLength(100, MinimumLength = 3, ErrorMessage = nameof(UILabels.StringLengthRange))]
        public string Title { get; set; }

        [Display(Name = nameof(UILabels.Record_Year))]
        [Range(0, int.MaxValue, ErrorMessage = nameof(UILabels.MinValue))]
        [RegularExpression("\\d+", ErrorMessage = nameof(UILabels.NotANumber))]
        public int Year { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = nameof(UILabels.Record_Price))]
        [Range(0, double.MaxValue, ErrorMessage = nameof(UILabels.MinValue))]
        [RegularExpression("\\d+(?:[,.]\\d*)?", ErrorMessage = nameof(UILabels.NotANumber))]
        public double Price { get; set; }

        [Display(Name = nameof(UILabels.Record_Description))]
        [MaxLength(256, ErrorMessage = nameof(UILabels.StringMaxLength))]
        public string? Description { get; set; }

        [Display(Name = nameof(UILabels.Record_Format))]
        public Guid? FormatId { get; set; }

        [Display(Name = nameof(UILabels.Record_Release))]
        public Guid? ReleaseId { get; set; }

        [Display(Name = nameof(UILabels.Record_RecordCondition))]
        public Guid? RecordConditionId { get; set; }

        [Display(Name = nameof(UILabels.Record_Categories))]
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        //public IEnumerable<Guid> Artists { get; set; } = new List<Guid>();

        [Display(Name = nameof(UILabels.Record_Genres))]
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

        [Display(Name = nameof(UILabels.Record_Styles))]
        public List<StyleViewModel> Styles { get; set; } = new List<StyleViewModel>();

        [Display(Name = nameof(UILabels.Record_Photos))]
        public List<string> Photos { get; set; } = new List<string>();
    }
}
