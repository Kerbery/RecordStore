using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class GenreServices : BaseServices<Genre>, IGenreServices
    {
        public GenreServices(IRepository<Genre> genreRepository) : base(genreRepository) { }

        public async Task<Genre> CreateAsync(CreateGenreDTO createGenreDTO)
        {
            var genre = new Genre { Name = createGenreDTO.Name };
            await CreateAsync(genre);
            return genre;
        }

        public async Task UpdateAsync(Guid id, UpdateGenreDTO updateGenreDTO)
        {
            var existingGenre = await GetAsync(id);
            existingGenre.Name = updateGenreDTO.Name;

            await UpdateAsync(existingGenre);
        }
    }
}
