namespace Melodix.MVC.Services.SpotifyApis.Models
{
    public class SpotifyAlbumDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Artists { get; set; }
        public string ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string[] TrackIds { get; set; }
    }
}