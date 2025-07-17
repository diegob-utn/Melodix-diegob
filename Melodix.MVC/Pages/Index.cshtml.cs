using Melodix.Keys;
using Melodix.MVC.Services.SpotifyApis.Models;
using Melodix.MVC.Services.SpotifyApis.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Melodix.MVC.Pages
{
    public class Index:PageModel
    {
        public List<SpotifyAlbumDto> PopularAlbums { get; set; } = new();
        public List<SpotifyPlaylistDto> FeaturedPlaylists { get; set; } = new();

        private readonly ISpotifyWebApiAdapter _spotifyWebApiAdapter;

        public Index(ISpotifyWebApiAdapter spotifyWebApiAdapter)
        {
            _spotifyWebApiAdapter = spotifyWebApiAdapter;
        }

        public async Task OnGetAsync()
        {
            string accessToken = await SpotifyAuthHelper.GetAccessTokenAsync(SpotifyKeys.ClientId, SpotifyKeys.ClientSecret);
            var albumsJson = await _spotifyWebApiAdapter.GetNewReleasesAsync(accessToken);
            var playlistsJson = await _spotifyWebApiAdapter.GetFeaturedPlaylistsAsync(accessToken);

            PopularAlbums = SpotifyApiParser.ParseAlbums(albumsJson) ?? new List<SpotifyAlbumDto>();
            FeaturedPlaylists = SpotifyApiParser.ParsePlaylists(playlistsJson) ?? new List<SpotifyPlaylistDto>();
        }
    }
}