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
        [Display(Name = nameof(UILabels.Record_ID))]
        public Guid Id { get; set; }

        [Display(Name = nameof(UILabels.Record_Title))]
        public string Title { get; set; }

        [Display(Name = nameof(UILabels.Record_Year))]
        public int Year { get; set; }

        [Display(Name = nameof(UILabels.Record_Price))]
        public double Price { get; set; }

        [Display(Name = nameof(UILabels.Record_Description))]
        public string? Description { get; set; }

        [Display(Name = nameof(UILabels.Record_CreatedOn))]
        public DateTimeOffset CreateDate { get; set; }

        [Display(Name = nameof(UILabels.Record_Format))]
        public GetFormatDTO? Format { get; set; }

        [Display(Name = nameof(UILabels.Record_Release))]
        public GetReleaseDTO? Release { get; set; }

        [Display(Name = nameof(UILabels.Record_RecordCondition))]
        public GetConditionDTO? RecordCondition { get; set; }

        [Display(Name = nameof(UILabels.Record_Categories))]
        public IEnumerable<GetCategoryDTO> Categories { get; set; } = Enumerable.Empty<GetCategoryDTO>();
        //public IEnumerable<GetArtistDTO> Artists { get; set; } = Enumerable.Empty<GetArtistDTO>();

        [Display(Name = nameof(UILabels.Record_Genres))]
        public IEnumerable<GetGenreDTO> Genres { get; set; } = Enumerable.Empty<GetGenreDTO>();

        [Display(Name = nameof(UILabels.Record_Styles))]
        public IEnumerable<GetStyleDTO> Styles { get; set; } = Enumerable.Empty<GetStyleDTO>();

        [Display(Name = nameof(UILabels.Record_Photos))]
        public IEnumerable<string> Photos { get; set; } = Enumerable.Empty<string>();
    }
}
