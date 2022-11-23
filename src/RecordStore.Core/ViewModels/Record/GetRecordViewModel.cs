using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;

namespace RecordStore.Core.ViewModels.Record
{
    public class GetRecordViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public GetFormatDTO Format { get; set; }
        public GetReleaseDTO Release { get; set; }
        public GetConditionDTO RecordCondition { get; set; }
        public ICollection<GetCategoryDTO> Categories { get; set; }
        //public ICollection<GetArtistDTO> Artists { get; set; }
        public ICollection<GetGenreDTO> Genres { get; set; }
        public ICollection<GetStyleDTO> Styles { get; set; }
        //public ICollection<Photo> Photos { get; set; }
    }
}
