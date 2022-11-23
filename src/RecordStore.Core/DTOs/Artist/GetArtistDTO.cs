using RecordStore.Core.ViewModels.Record;

namespace RecordStore.Core.DTOs.Artist
{
    public class GetArtistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        //public ICollection<GetPhotoDTO> Photos { get; set; }
        public ICollection<GetRecordViewModel> Records { get; set; } = new List<GetRecordViewModel>();
    }
}
