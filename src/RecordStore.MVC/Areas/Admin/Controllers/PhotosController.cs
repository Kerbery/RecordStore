using Microsoft.AspNetCore.Mvc;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoServices _photoServices;

        public PhotosController(IPhotoServices photoServices)
        {
            _photoServices = photoServices;
        }

        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(string id)
        {
            //var photo = (await _photoServices.GetAsync(id)).AsDTO();

            //return Ok(photo);
            return Redirect("/Images/Thumbs/" + id.Replace("\"", ""));
        }

        // POST api/<PhotosController>
        [HttpPost]
        public async Task<ActionResult> PostAsync(List<IFormFile> Photos)
        {
            var createdPhotosFileNames = new List<string>();
            foreach (var photo in Photos)
            {
                var storedPhoto = await _photoServices.StorePhoto(photo);
                createdPhotosFileNames.Add(storedPhoto.Filename);
            }

            return Ok(string.Join("\r\n", createdPhotosFileNames));
        }

        // DELETE api/<PhotosController>/5
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] string file)
        {
            var existingPhoto = await _photoServices.GetAsync(file);
            if (existingPhoto is null)
            {
                return NotFound();
            }
            await _photoServices.DeleteAsync(existingPhoto.Id);
            return Ok();
        }
    }
}
