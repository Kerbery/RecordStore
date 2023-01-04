using RecordStore.Core.Resources;
using RecordStore.Core.ViewModels.Category;
using RecordStore.Core.ViewModels.Genre;
using RecordStore.Core.ViewModels.Style;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.Record
{
    public class EditRecordViewModel
    {
        [Display(Name = nameof(UILabels.Record_Title), ResourceType = typeof(UILabels))]
        [Required(ErrorMessageResourceName = nameof(UILabels.FieldRequired), ErrorMessageResourceType = typeof(UILabels))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = nameof(UILabels.StringLengthRange), ErrorMessageResourceType = typeof(UILabels))]
        public string Title { get; set; }

        [Display(Name = nameof(UILabels.Record_Year), ResourceType = typeof(UILabels))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = nameof(UILabels.MinValue), ErrorMessageResourceType = typeof(UILabels))]
        [RegularExpression("\\d+", ErrorMessageResourceName = nameof(UILabels.NotANumber), ErrorMessageResourceType = typeof(UILabels))]
        public int Year { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = nameof(UILabels.Record_Price), ResourceType = typeof(UILabels))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = nameof(UILabels.MinValue), ErrorMessageResourceType = typeof(UILabels))]
        [RegularExpression("\\d+(?:[,.]\\d*)?", ErrorMessageResourceName = nameof(UILabels.NotANumber), ErrorMessageResourceType = typeof(UILabels))]
        public double Price { get; set; }

        [Display(Name = nameof(UILabels.Record_Description), ResourceType = typeof(UILabels))]
        [MaxLength(256, ErrorMessageResourceName = nameof(UILabels.StringMaxLength), ErrorMessageResourceType = typeof(UILabels))]
        public string? Description { get; set; }

        [Display(Name = nameof(UILabels.Record_Format), ResourceType = typeof(UILabels))]
        public Guid? FormatId { get; set; }

        [Display(Name = nameof(UILabels.Record_Release), ResourceType = typeof(UILabels))]
        public Guid? ReleaseId { get; set; }

        [Display(Name = nameof(UILabels.Record_RecordCondition), ResourceType = typeof(UILabels))]
        public Guid? RecordConditionId { get; set; }

        [Display(Name = nameof(UILabels.Record_Categories), ResourceType = typeof(UILabels))]
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        //public IEnumerable<Guid> Artists { get; set; } = new List<Guid>();

        [Display(Name = nameof(UILabels.Record_Genres), ResourceType = typeof(UILabels))]
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

        [Display(Name = nameof(UILabels.Record_Styles), ResourceType = typeof(UILabels))]
        public List<StyleViewModel> Styles { get; set; } = new List<StyleViewModel>();

        [Display(Name = nameof(UILabels.Record_Photos), ResourceType = typeof(UILabels))]
        public List<string> Photos { get; set; } = new List<string>();
    }
}
