using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Core.ViewModels.Record;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class RecordServices : BaseServices<Record>, IRecordServices
    {
        public RecordServices(IRepository<Record> repository) : base(repository) { }
        public async Task<IdentityResult> CreateAsync(CreateRecordViewModel createRecordViewModel)
        {
            var record = new Record
            {
                Title = createRecordViewModel.Title,
                Description = createRecordViewModel.Description,
                Price = createRecordViewModel.Price,
                Year = createRecordViewModel.Year,
                //Format = createRecordViewModel.Format,
                //Release = createRecordViewModel.Release,
                //RecordCondition = createRecordViewModel.RecordCondition,
                //Artists = createRecordViewModel.Artists,
                //Genres = createRecordViewModel.Genres,
                //Styles = createRecordViewModel.Styles,
                //Categories = createRecordViewModel.Categories,
                //Photos = createRecordViewModel.Photos
            };

            await CreateAsync(record);
            return IdentityResult.Success;
        }

        public async Task UpdateAsync(EditRecordViewModel editRecordViewModel)
        {
            var record = new Record
            {
                Title = editRecordViewModel.Title,
                Description = editRecordViewModel.Description,
                Price = editRecordViewModel.Price,
                Year = editRecordViewModel.Year,
                //Format = editRecordViewModel.Format,
                //Release = editRecordViewModel.Release,
                //RecordCondition = editRecordViewModel.RecordCondition,
                //Artists = editRecordViewModel.Artists,
                //Genres = editRecordViewModel.Genres,
                //Styles = editRecordViewModel.Styles,
                //Categories = editRecordViewModel.Categories,
                //Photos = editRecordViewModel.Photos
            };

            await UpdateAsync(record);
        }
    }
}
