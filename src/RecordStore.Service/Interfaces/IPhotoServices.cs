using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IPhotoServices : IBaseServices<Photo>
    {
        Task<Photo?> GetAsync(string fileName);
    }
}