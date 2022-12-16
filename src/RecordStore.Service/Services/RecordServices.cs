﻿using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Core.ViewModels.Record;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class RecordServices : BaseServices<Record>, IRecordServices
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Style> _styleRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Photo> _photoRepository;
        public RecordServices(
            IRepository<Record> recordRepository,
            IRepository<Genre> genreRepository,
            IRepository<Style> styleRepository,
            IRepository<Category> categoryRepository,
            IRepository<Photo> photoRepository) : base(recordRepository)
        {
            _genreRepository = genreRepository;
            _styleRepository = styleRepository;
            _categoryRepository = categoryRepository;
            _photoRepository = photoRepository;
        }

        public new async Task<Record?> GetAsync(Guid id)
        {
            return await _repository.GetAsync(
                id,
                r => r.RecordCondition,
                r => r.Format,
                r => r.Genres,
                r => r.Release,
                r => r.Styles,
                r => r.Categories,
                r => r.Photos);
        }

        public new async Task<IEnumerable<Record>> GetAllAsync()
        {
            return await _repository.GetAllAsync(
                r => r.RecordCondition,
                r => r.Format,
                r => r.Genres,
                r => r.Release,
                r => r.Styles,
                r => r.Categories,
                r => r.Photos);
        }

        public async Task<IdentityResult> CreateAsync(CreateRecordViewModel createRecordViewModel)
        {
            var selectedGenres = createRecordViewModel.Genres.Where(g => g.IsSelected).Select(g => g.Id);
            var selectedStyles = createRecordViewModel.Styles.Where(g => g.IsSelected).Select(g => g.Id);
            var selectedCategories = createRecordViewModel.Categories.Where(g => g.IsSelected).Select(g => g.Id);

            var record = new Record
            {
                Title = createRecordViewModel.Title,
                Description = createRecordViewModel.Description,
                Price = createRecordViewModel.Price,
                Year = createRecordViewModel.Year,
                FormatId = createRecordViewModel.FormatId,
                ReleaseId = createRecordViewModel.ReleaseId,
                RecordConditionId = createRecordViewModel.RecordConditionId,
                Genres = (ICollection<Genre>)await _genreRepository.GetAllAsync(g => selectedGenres.Contains(g.Id)),
                Styles = (ICollection<Style>)await _styleRepository.GetAllAsync(s => selectedStyles.Contains(s.Id)),
                Categories = (ICollection<Category>)await _categoryRepository.GetAllAsync(c => selectedCategories.Contains(c.Id)),
                //Artists = createRecordViewModel.Artists,
                Photos = createRecordViewModel.Photos.Select((fileName, index) => new Photo { Filename = fileName, Position = index }).ToList(),
            };

            await CreateAsync(record);
            return IdentityResult.Success;
        }

        public async Task UpdateAsync(Guid id, EditRecordViewModel editRecordViewModel)
        {
            var selectedGenres = editRecordViewModel.Genres.Where(g => g.IsSelected).Select(g => g.Id);
            var selectedStyles = editRecordViewModel.Styles.Where(g => g.IsSelected).Select(g => g.Id);
            var selectedCategories = editRecordViewModel.Categories.Where(g => g.IsSelected).Select(g => g.Id);

            var existingRecord = await _repository.GetAsync(id, r => r.Genres, r => r.Styles, r => r.Categories);

            if (existingRecord is null)
            {
                return;
            }

            existingRecord.Title = editRecordViewModel.Title;
            existingRecord.Description = editRecordViewModel.Description;
            existingRecord.Price = editRecordViewModel.Price;
            existingRecord.Year = editRecordViewModel.Year;
            existingRecord.FormatId = editRecordViewModel.FormatId;
            existingRecord.ReleaseId = editRecordViewModel.ReleaseId;
            existingRecord.RecordConditionId = editRecordViewModel.RecordConditionId;
            existingRecord.Genres = (ICollection<Genre>)await _genreRepository.GetAllAsync(g => selectedGenres.Contains(g.Id));
            existingRecord.Styles = (ICollection<Style>)await _styleRepository.GetAllAsync(s => selectedStyles.Contains(s.Id));
            existingRecord.Categories = (ICollection<Category>)await _categoryRepository.GetAllAsync(c => selectedCategories.Contains(c.Id));
            //existingRecord.Artists = editRecordViewModel.Artists;
            existingRecord.Photos = (ICollection<Photo>)await _photoRepository.GetAllAsync(p => editRecordViewModel.Photos.Contains(p.Filename));

            existingRecord.Photos = existingRecord.Photos.Select(photo =>
            {
                photo.Position = editRecordViewModel.Photos.IndexOf(photo.Filename);
                return photo;
            }).ToList();

            await UpdateAsync(existingRecord);
        }
    }
}
