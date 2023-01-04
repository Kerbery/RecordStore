using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.ViewModels.Record
{
    public class GetRecordViewModel
    {
        [Display(Name = nameof(UILabels.Record_ID), ResourceType = typeof(UILabels))]
        public Guid Id { get; set; }

        [Display(Name = nameof(UILabels.Record_Title), ResourceType = typeof(UILabels))]
        public string Title { get; set; }

        [Display(Name = nameof(UILabels.Record_Year), ResourceType = typeof(UILabels))]
        public int Year { get; set; }

        [Display(Name = nameof(UILabels.Record_Price), ResourceType = typeof(UILabels))]
        public double Price { get; set; }

        [Display(Name = nameof(UILabels.Record_Description), ResourceType = typeof(UILabels))]
        public string? Description { get; set; }

        [Display(Name = nameof(UILabels.Record_CreatedOn), ResourceType = typeof(UILabels))]
        public DateTimeOffset CreateDate { get; set; }

        [Display(Name = nameof(UILabels.Record_Format), ResourceType = typeof(UILabels))]
        public GetFormatDTO? Format { get; set; }

        [Display(Name = nameof(UILabels.Record_Release), ResourceType = typeof(UILabels))]
        public GetReleaseDTO? Release { get; set; }

        [Display(Name = nameof(UILabels.Record_RecordCondition), ResourceType = typeof(UILabels))]
        public GetConditionDTO? RecordCondition { get; set; }

        [Display(Name = nameof(UILabels.Record_Categories), ResourceType = typeof(UILabels))]
        public IEnumerable<GetCategoryDTO> Categories { get; set; } = Enumerable.Empty<GetCategoryDTO>();
        //public IEnumerable<GetArtistDTO> Artists { get; set; } = Enumerable.Empty<GetArtistDTO>();

        [Display(Name = nameof(UILabels.Record_Genres), ResourceType = typeof(UILabels))]
        public IEnumerable<GetGenreDTO> Genres { get; set; } = Enumerable.Empty<GetGenreDTO>();

        [Display(Name = nameof(UILabels.Record_Styles), ResourceType = typeof(UILabels))]
        public IEnumerable<GetStyleDTO> Styles { get; set; } = Enumerable.Empty<GetStyleDTO>();

        [Display(Name = nameof(UILabels.Record_Photos), ResourceType = typeof(UILabels))]
        public IEnumerable<string> Photos { get; set; } = Enumerable.Empty<string>();
    }
}
