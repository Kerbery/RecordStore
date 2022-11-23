using RecordStore.Core.DTOs.Format;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class FormatServices : BaseServices<Format>, IFormatServices
    {
        public FormatServices(IRepository<Format> formatRepository) : base(formatRepository) { }

        public async Task<Format> CreateAsync(CreateFormatDTO createFormatDTO)
        {
            var format = new Format { Name = createFormatDTO.Name };
            await CreateAsync(format);
            return format;
        }

        public async Task UpdateAsync(Guid id, UpdateFormatDTO updateFormatDTO)
        {
            var existingFormat = await GetAsync(id);
            existingFormat.Name = updateFormatDTO.Name;

            await UpdateAsync(existingFormat);
        }
    }
}
