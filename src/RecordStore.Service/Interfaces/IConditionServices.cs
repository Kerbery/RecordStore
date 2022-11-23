using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IConditionServices : IBaseServices<Condition>
    {
        Task<Condition> CreateAsync(CreateConditionDTO createConditionDTO);
        Task UpdateAsync(Guid id, UpdateConditionDTO updateConditionDTO);
    }
}