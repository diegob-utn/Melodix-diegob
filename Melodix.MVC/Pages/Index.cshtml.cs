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
        public string SpotifyToken { get; set; }

        public List<SpotifyAlbumDto> PopularAlbums { get; set; } = new();
        public List<SpotifyPlaylistDto> FeaturedPlaylists { get; set; } = new();

        private readonly ISpotifyWebApiAdapter _spotifyWebApiAdapter;

        public Index(ISpotifyWebApiAdapter spotifyWebApiAdapter)
        {
            _spotifyWebApiAdapter = spotifyWebApiAdapter;
        }

        // Usa OnGetAsync por convención para métodos async
        public async Task OnGetAsync()
        {
            try
            {
                SpotifyToken = await SpotifyAuthHelper.GetAccessTokenAsync(SpotifyKeys.ClientId, SpotifyKeys.ClientSecret);
                var albumsJson = await _spotifyWebApiAdapter.GetNewReleasesAsync(SpotifyToken);
                var playlistsJson = await _spotifyWebApiAdapter.GetFeaturedPlaylistsAsync(SpotifyToken);

                PopularAlbums = SpotifyApiParser.ParseAlbums(albumsJson) ?? new List<SpotifyAlbumDto>();
                FeaturedPlaylists = SpotifyApiParser.ParsePlaylists(playlistsJson) ?? new List<SpotifyPlaylistDto>();

                // Depuración opcional
                System.Diagnostics.Debug.WriteLine("Playlists JSON:");
                System.Diagnostics.Debug.WriteLine(playlistsJson);
                System.Diagnostics.Debug.WriteLine($"Playlists parseadas: {FeaturedPlaylists.Count}");
            }
            catch(Exception ex)
            {
                // Manejo simple de errores, puedes mostrar un mensaje en la vista si lo deseas
                System.Diagnostics.Debug.WriteLine($"Error obteniendo datos de Spotify: {ex.Message}");
                PopularAlbums = new List<SpotifyAlbumDto>();
                FeaturedPlaylists = new List<SpotifyPlaylistDto>();
                SpotifyToken = "";
            }
        }
    }
}