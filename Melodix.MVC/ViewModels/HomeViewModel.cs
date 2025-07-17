using Melodix.MVC.Services.SpotifyApis.Models;
using System.Collections.Generic;

public class HomeViewModel
{
    public List<SpotifyAlbumDto> PopularAlbums { get; set; } = new();
    public List<SpotifyPlaylistDto> FeaturedPlaylists { get; set; } = new();
}
