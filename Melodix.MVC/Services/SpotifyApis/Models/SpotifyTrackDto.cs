public class SpotifyTrackDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string AlbumName { get; set; }
    public string[] Artists { get; set; }
    public string PreviewUrl { get; set; }
    public string ImageUrl { get; set; }
    public int DurationMs { get; set; }
}