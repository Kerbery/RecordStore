using RecordStore.Core.DTOs.Artist;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IArtistServices : IBaseServices<Artist>
    {
        Task<Artist> CreateAsync(CreateArtistDTO createArtistDTO);
        Task UpdateAsync(Guid id, UpdateArtistDTO updateArtistDTO);
    }
}