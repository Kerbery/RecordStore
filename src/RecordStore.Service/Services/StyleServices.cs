using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class StyleServices : BaseServices<Style>, IStyleServices
    {
        public StyleServices(IRepository<Style> styleRepository) : base(styleRepository) { }

        public async Task<Style> CreateAsync(CreateStyleDTO createStyleDTO)
        {
            var style = new Style { Name = createStyleDTO.Name };
            await CreateAsync(style);
            return style;
        }

        public async Task UpdateAsync(Guid id, UpdateStyleDTO updateStyleDTO)
        {
            var existingStyle = await GetAsync(id);
            existingStyle.Name = updateStyleDTO.Name;

            await UpdateAsync(existingStyle);
        }
    }
}
