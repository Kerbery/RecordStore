using RecordStore.Core.DTOs.Category;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface ICategoryServices : IBaseServices<Category>
    {
        Task<Category> CreateAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateAsync(Guid id, UpdateCategoryDTO updateCategoryDTO);
    }
}