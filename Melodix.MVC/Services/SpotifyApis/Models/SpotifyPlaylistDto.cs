namespace Melodix.MVC.Services.SpotifyApis.Models
{
    public class SpotifyPlaylistDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int TotalTracks { get; set; }
        public string[] TrackIds { get; set; }
    }
}