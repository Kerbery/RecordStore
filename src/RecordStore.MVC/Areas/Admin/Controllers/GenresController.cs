using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServices _genreServices;

        public GenresController(IGenreServices genreServices)
        {
            _genreServices = genreServices;
        }

        // GET: api/<GenresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGenreDTO>>> GetAsync()
        {
            var genres = (await _genreServices.GetAllAsync())
                .Select(g => g.AsDTO());

            return Ok(genres);
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetGenreDTO>> GetAsync(Guid id)
        {
            var genre = (await _genreServices.GetAsync(id)).AsDTO();

            return Ok(genre);
        }

        // POST api/<GenresController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateGenreDTO createGenreDTO)
        {
            var createdGenre = await _genreServices.CreateAsync(createGenreDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdGenre.Id }, createdGenre.AsDTO());
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromForm] UpdateGenreDTO updateGenreDTO)
        {
            if (ModelState.IsValid)
            {
                await _genreServices.UpdateAsync(id, updateGenreDTO);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _genreServices.DeleteAsync(id);
            return Ok();
        }
    }
}
