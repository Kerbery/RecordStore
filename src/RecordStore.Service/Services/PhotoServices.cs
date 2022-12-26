using FluentFTP;
using Microsoft.AspNetCore.Http;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Core.Settings;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class PhotoServices : BaseServices<Photo>, IPhotoServices
    {
        public FtpSettings FtpSettings { get; set; }
        public PhotoServices(IRepository<Photo> genreRepository, FtpSettings ftpSettings) : base(genreRepository)
        {
            FtpSettings = ftpSettings;
        }

        public async Task<Photo?> GetAsync(string fileName)
        {
            return await _repository.GetAsync(p => p.Filename == fileName);
        }

        public async Task<Photo> StorePhoto(IFormFile file)
        {
            var photo = await StoreStoreOnFtp(file);
            await _repository.CreateAsync(photo);
            return photo;
        }

        private async Task<Photo> StoreStoreOnFtp(IFormFile image)
        {
            var photo = new Photo();
            var extension = Path.GetExtension(image.FileName);
            photo.Filename = $"{photo.Id}{extension}";
            var path = $"{FtpSettings.OriginalsPath}/{photo.Filename}";

            using var client = new FtpClient(FtpSettings.Host, FtpSettings.Username, FtpSettings.Password);
            client.Connect();

            client.UploadStream(image.OpenReadStream(), path, FtpRemoteExists.Overwrite, true);

            return photo;
        }
    }
}
