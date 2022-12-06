using Microsoft.AspNetCore.Identity;
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
        public RecordServices(
            IRepository<Record> recordRepository,
            IRepository<Genre> genreRepository,
            IRepository<Style> styleRepository,
            IRepository<Category> categoryRepository) : base(recordRepository)
        {
            _genreRepository = genreRepository;
            _styleRepository = styleRepository;
            _categoryRepository = categoryRepository;
        }

        public new async Task<Record> GetAsync(Guid id)
        {
            return await _repository.GetAsync(
                id,
                r => r.RecordCondition,
                r => r.Format,
                r => r.Genres,
                r => r.Release,
                r => r.Styles,
                r => r.Categories);
        }

        public new async Task<IEnumerable<Record>> GetAllAsync()
        {
            return await _repository.GetAllAsync(
                r => r.RecordCondition,
                r => r.Format,
                r => r.Genres,
                r => r.Release,
                r => r.Styles,
                r => r.Categories);
        }

        public async Task<IdentityResult> CreateAsync(CreateRecordViewModel createRecordViewModel)
        {
            var record = new Record
            {
                Title = createRecordViewModel.Title,
                Description = createRecordViewModel.Description,
                Price = createRecordViewModel.Price,
                Year = createRecordViewModel.Year,
                FormatId = createRecordViewModel.FormatId,
                ReleaseId = createRecordViewModel.ReleaseId,
                RecordConditionId = createRecordViewModel.RecordConditionId,
                Genres = (ICollection<Genre>)await _genreRepository.GetAllAsync(g => (createRecordViewModel.Genres ?? new List<Guid>()).Contains(g.Id)),
                Styles = (ICollection<Style>)await _styleRepository.GetAllAsync(s => (createRecordViewModel.Styles ?? new List<Guid>()).Contains(s.Id)),
                Categories = (ICollection<Category>)await _categoryRepository.GetAllAsync(c => (createRecordViewModel.Categories ?? new List<Guid>()).Contains(c.Id)),
                //Artists = createRecordViewModel.Artists,
                //Photos = createRecordViewModel.Photos
            };

            await CreateAsync(record);
            return IdentityResult.Success;
        }

        public async Task UpdateAsync(Guid id, EditRecordViewModel editRecordViewModel)
        {
            var existingRecord = await _repository.GetAsync(id, r => r.Genres, r => r.Styles, r => r.Categories);

            existingRecord.Title = editRecordViewModel.Title;
            existingRecord.Description = editRecordViewModel.Description;
            existingRecord.Price = editRecordViewModel.Price;
            existingRecord.Year = editRecordViewModel.Year;
            existingRecord.FormatId = editRecordViewModel.FormatId;
            existingRecord.ReleaseId = editRecordViewModel.ReleaseId;
            existingRecord.RecordConditionId = editRecordViewModel.RecordConditionId;
            existingRecord.Genres = (ICollection<Genre>)await _genreRepository.GetAllAsync(g => (editRecordViewModel.Genres ?? new List<Guid>()).Contains(g.Id));
            existingRecord.Styles = (ICollection<Style>)await _styleRepository.GetAllAsync(s => (editRecordViewModel.Styles ?? new List<Guid>()).Contains(s.Id));
            existingRecord.Categories = (ICollection<Category>)await _categoryRepository.GetAllAsync(c => (editRecordViewModel.Categories ?? new List<Guid>()).Contains(c.Id));
            //existingRecord.Artists = editRecordViewModel.Artists;
            //existingRecord.Photos = editRecordViewModel.Photos

            await UpdateAsync(existingRecord);
        }
    }
}
