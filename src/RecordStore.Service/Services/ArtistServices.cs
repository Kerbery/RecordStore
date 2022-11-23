using RecordStore.Core.DTOs.Artist;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class ArtistServices : BaseServices<Artist>, IArtistServices
    {
        public ArtistServices(IRepository<Artist> artistRepository) : base(artistRepository) { }

        public async Task<Artist> CreateAsync(CreateArtistDTO createArtistDTO)
        {
            var artist = new Artist { Name = createArtistDTO.Name, Description = createArtistDTO.Description };
            await CreateAsync(artist);
            return artist;
        }

        public async Task UpdateAsync(Guid id, UpdateArtistDTO updateArtistDTO)
        {
            var existingArtist = await GetAsync(id);
            existingArtist.Name = updateArtistDTO.Name;
            existingArtist.Description = updateArtistDTO.Description;

            await UpdateAsync(existingArtist);
        }
    }
}
