using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class ConditionServices : BaseServices<Condition>, IConditionServices
    {
        public ConditionServices(IRepository<Condition> conditionRepository) : base(conditionRepository) { }

        public async Task<Condition> CreateAsync(CreateConditionDTO createConditionDTO)
        {
            var condition = new Condition { Name = createConditionDTO.Name };
            await CreateAsync(condition);
            return condition;
        }

        public async Task UpdateAsync(Guid id, UpdateConditionDTO updateConditionDTO)
        {
            var existingCondition = await GetAsync(id);
            existingCondition.Name = updateConditionDTO.Name;

            await UpdateAsync(existingCondition);
        }
    }
}
