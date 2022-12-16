using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
using System.ComponentModel;

namespace RecordStore.Core.ViewModels.Record
{
    public class GetRecordViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        [DisplayName("Created On")]
        public DateTimeOffset CreateDate { get; set; }
        public GetFormatDTO? Format { get; set; }
        public GetReleaseDTO? Release { get; set; }
        [DisplayName("Record Condition")]
        public GetConditionDTO? RecordCondition { get; set; }
        public IEnumerable<GetCategoryDTO> Categories { get; set; }
        //public IEnumerable<GetArtistDTO> Artists { get; set; }
        public IEnumerable<GetGenreDTO> Genres { get; set; }
        public IEnumerable<GetStyleDTO> Styles { get; set; }
        //public IEnumerable<Photo> Photos { get; set; }
    }
}
