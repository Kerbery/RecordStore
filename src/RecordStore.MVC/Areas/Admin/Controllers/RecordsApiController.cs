using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Record;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsApiController : ControllerBase
    {
        private readonly IRecordServices _recordServices;

        public RecordsApiController(IRecordServices recordServices)
        {
            _recordServices = recordServices;
        }

        // GET: api/<RecordsController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GetRecordDTO>>> GetAsync()
        {
            var records = await _recordServices.GetAllAsync();
            return Ok(new
            {
                draw = 1,
                data = records.Select(g => g.AsDTO()),
                recordsTotal = records.Count(),
                recordsFiltered = records.Count(),
            });
        }
    }
}
