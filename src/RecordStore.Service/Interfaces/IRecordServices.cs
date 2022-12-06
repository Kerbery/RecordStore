using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.ViewModels.Record;

namespace RecordStore.Service.Interfaces
{
    public interface IRecordServices : IBaseServices<Record>
    {
        Task<IdentityResult> CreateAsync(CreateRecordViewModel record);
        Task UpdateAsync(Guid id, EditRecordViewModel record);
    }
}