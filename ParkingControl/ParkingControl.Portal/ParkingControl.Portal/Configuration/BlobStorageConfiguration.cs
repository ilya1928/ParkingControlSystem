namespace ParkingControl.Portal.Configuration
{
    public class BlobStorageConfiguration
    {
        public string ProfileImagesContainer { get; set; }
        public string ProfileImagesLink { get; set; }
        public string NoProfileImageLink { get; set; }
        public string LicensePlatesLink { get; set; }
        public string PanoramasLink { get; set; }
        public string JpegExtension { get; set; }
    }
}
