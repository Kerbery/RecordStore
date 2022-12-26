using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
using System.ComponentModel;

namespace RecordStore.Core.DTOs.Record
{
    public class GetRecordDTO
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
        public IEnumerable<GetCategoryDTO> Categories { get; set; } = Enumerable.Empty<GetCategoryDTO>();
        //public IEnumerable<GetArtistDTO> Artists { get; set; } = Enumerable.Empty<GetArtistDTO>();
        public IEnumerable<GetGenreDTO> Genres { get; set; } = Enumerable.Empty<GetGenreDTO>();
        public IEnumerable<GetStyleDTO> Styles { get; set; } = Enumerable.Empty<GetStyleDTO>();
        public IEnumerable<string> Photos { get; set; } = Enumerable.Empty<string>();
    }
}
