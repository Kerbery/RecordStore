﻿using RecordStore.Core.DTOs.Category;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IRepository<Category> categoryRepository) : base(categoryRepository) { }

        public async Task<Category> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = new Category
            {
                Name = createCategoryDTO.Name,
                Position = createCategoryDTO.Position,
                ParentCategoryId = createCategoryDTO.ParentCategoryId
            };
            await CreateAsync(category);
            return category;
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDTO updateCategoryDTO)
        {
            Category existingCategory = await GetAsync(id);
            existingCategory.Name = updateCategoryDTO.Name;
            existingCategory.Position = updateCategoryDTO.Position;
            existingCategory.ParentCategoryId = updateCategoryDTO.ParentCategoryId;

            await UpdateAsync(existingCategory);
        }
    }
}
