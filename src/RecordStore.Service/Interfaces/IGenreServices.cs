using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IGenreServices : IBaseServices<Genre>
    {
        Task<Genre> CreateAsync(CreateGenreDTO createGenreDTO);
        Task UpdateAsync(Guid id, UpdateGenreDTO updateGenreDTO);
    }
}