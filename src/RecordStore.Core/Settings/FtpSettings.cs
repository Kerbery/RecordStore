namespace RecordStore.Core.Settings
{
    public class FtpSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public string OriginalsPath { get; set; }
        public string ThumbnailsPath { get; set; }
        public string TemporaryPath { get; set; }

        public string Root => $"ftp://{Host}:{Port}";
        public string OriginalPhotosLocation => $"{Root}{OriginalsPath}";
        public string ThumbnailsLocation => $"{Root}{ThumbnailsPath}";
        public string TempPhotosLocation => $"{Root}{TemporaryPath}";
    }
}
