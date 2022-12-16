using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.Entities.Models;
using RecordStore.Service.Interfaces;
using System.Net;

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
            return Redirect("/Images/Temp/" + id.Replace("\"", ""));
        }

        private static bool StorePhoto(IFormFile Image)
        {
            //Create an FtpWebRequest
            var request = (FtpWebRequest)WebRequest.Create($"ftp://127.0.0.1/RecordStore/Images/Temp/{Image.FileName}");
            //Set the method to UploadFile
            request.Method = WebRequestMethods.Ftp.UploadFile;
            //Set the NetworkCredentials
            request.Credentials = new NetworkCredential("RecordStore", "RecordStore");

            //Set buffer length to any value you find appropriate for your use case
            byte[] buffer = new byte[1024];
            var stream = Image.OpenReadStream();
            byte[] fileContents;
            //Copy everything to the 'fileContents' byte array
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                fileContents = ms.ToArray();
            }

            //Upload the 'fileContents' byte array 
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            //Get the response
            // Some proper handling is needed
            var response = (FtpWebResponse)request.GetResponse();
            return response.StatusCode == FtpStatusCode.FileActionOK;
        }

        // POST api/<PhotosController>
        [HttpPost]
        public async Task<ActionResult> PostAsync(List<IFormFile> Photos)
        {
            var createdPhotosFileNames = new List<string>();
            foreach (var photo in Photos)
            {
                StorePhoto(photo);
                var createdPhoto = await _photoServices.CreateAsync(new Photo { Filename = photo.FileName });
                createdPhotosFileNames.Add(createdPhoto.Filename);
            }

            //return CreatedAtAction(nameof(GetAsync), new { id = createdPhoto.Id }, createdPhoto.AsDTO());
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
