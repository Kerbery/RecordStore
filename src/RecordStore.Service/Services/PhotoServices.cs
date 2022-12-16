using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class PhotoServices : BaseServices<Photo>, IPhotoServices
    {
        public PhotoServices(IRepository<Photo> genreRepository) : base(genreRepository) { }

        public async Task<Photo?> GetAsync(string fileName)
        {
            return await _repository.GetAsync(q => q.Filename == fileName);
        }
    }
}
