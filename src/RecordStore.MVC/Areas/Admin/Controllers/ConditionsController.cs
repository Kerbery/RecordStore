using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsController : ControllerBase
    {
        private readonly IConditionServices _conditionServices;

        public ConditionsController(IConditionServices conditionServices)
        {
            _conditionServices = conditionServices;
        }

        // GET: api/<ConditionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetConditionDTO>>> GetAsync()
        {
            var conditions = (await _conditionServices.GetAllAsync())
                .Select(c => c.AsDTO());

            return Ok(conditions);
        }

        // GET api/<ConditionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetConditionDTO>> GetAsync(Guid id)
        {
            var condition = (await _conditionServices.GetAsync(id)).AsDTO();

            return Ok(condition);
                
        }

        // POST api/<ConditionsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateConditionDTO createConditionDTO)
        {
            var createdCondition = await _conditionServices.CreateAsync(createConditionDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdCondition.Id }, createdCondition.AsDTO());
        }

        // PUT api/<ConditionsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] UpdateConditionDTO updateConditionDTO)
        {
            await _conditionServices.UpdateAsync(id, updateConditionDTO);
            return Ok();
        }

        // DELETE api/<ConditionsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _conditionServices.DeleteAsync(id);
            return Ok();
        }
    }
}
