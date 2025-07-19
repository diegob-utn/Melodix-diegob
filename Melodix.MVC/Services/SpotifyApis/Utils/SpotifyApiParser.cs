using Melodix.MVC.Services.SpotifyApis.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace Melodix.MVC.Services.SpotifyApis.Utils
{
    public static class SpotifyApiParser
    {
        public static List<SpotifyAlbumDto> ParseAlbums(string json)
        {
            var albums = new List<SpotifyAlbumDto>();
            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("albums", out var albumsRoot))
                return albums;
            if (!albumsRoot.TryGetProperty("items", out var items))
                return albums;

            foreach (var item in items.EnumerateArray())
            {
                string? imageUrl = null;
                if (item.TryGetProperty("images", out var images) && images.GetArrayLength() > 0)
                    imageUrl = images[0].GetProperty("url").GetString();

                albums.Add(new SpotifyAlbumDto
                {
                    Id = item.TryGetProperty("id", out var id) ? id.GetString() : null,
                    Name = item.TryGetProperty("name", out var name) ? name.GetString() : null,
                    Artists = item.TryGetProperty("artists", out var artistsArr)
                        ? artistsArr.EnumerateArray().Select(a => a.TryGetProperty("name", out var artistName) ? artistName.GetString() : null).ToArray()
                        : null,
                    ReleaseDate = item.TryGetProperty("release_date", out var releaseDate) ? releaseDate.GetString() : null,
                    ImageUrl = imageUrl,
                    TrackIds = null // Puedes agregar lógica para extraer tracks si lo necesitas
                });
            }
            return albums;
        }

        public static List<SpotifyPlaylistDto> ParsePlaylists(string json)
        {
            var playlists = new List<SpotifyPlaylistDto>();
            if (string.IsNullOrWhiteSpace(json))
                return playlists;

            using var doc = JsonDocument.Parse(json);

            // Spotify Featured Playlists endpoint returns { "playlists": { "items": [...] } }
            JsonElement items;
            if (doc.RootElement.TryGetProperty("playlists", out var playlistsRoot) &&
                playlistsRoot.TryGetProperty("items", out items))
            {
                foreach (var item in items.EnumerateArray())
                {
                    string? imageUrl = null;
                    if (item.TryGetProperty("images", out var images) && images.GetArrayLength() > 0)
                        imageUrl = images[0].GetProperty("url").GetString();

                    playlists.Add(new SpotifyPlaylistDto
                    {
                        Id = item.TryGetProperty("id", out var id) ? id.GetString() : null,
                        Name = item.TryGetProperty("name", out var name) ? name.GetString() : null,
                        Owner = item.TryGetProperty("owner", out var ownerObj) && ownerObj.TryGetProperty("display_name", out var owner) ? owner.GetString() : null,
                        Description = item.TryGetProperty("description", out var description) ? description.GetString() : null,
                        ImageUrl = imageUrl,
                        TotalTracks = item.TryGetProperty("tracks", out var tracksObj) && tracksObj.TryGetProperty("total", out var totalTracks) ? totalTracks.GetInt32() : 0,
                        TrackIds = null // Puedes agregar lógica para extraer tracks si lo necesitas
                    });
                }
                return playlists;
            }

            // Si no existe la propiedad "playlists", intenta buscar "items" en la ra�z (para compatibilidad)
            if (doc.RootElement.TryGetProperty("items", out items))
            {
                foreach (var item in items.EnumerateArray())
                {
                    string? imageUrl = null;
                    if (item.TryGetProperty("images", out var images) && images.GetArrayLength() > 0)
                        imageUrl = images[0].GetProperty("url").GetString();

                    playlists.Add(new SpotifyPlaylistDto
                    {
                        Id = item.TryGetProperty("id", out var id) ? id.GetString() : null,
                        Name = item.TryGetProperty("name", out var name) ? name.GetString() : null,
                        Owner = item.TryGetProperty("owner", out var ownerObj) && ownerObj.TryGetProperty("display_name", out var owner) ? owner.GetString() : null,
                        Description = item.TryGetProperty("description", out var description) ? description.GetString() : null,
                        ImageUrl = imageUrl,
                        TotalTracks = item.TryGetProperty("tracks", out var tracksObj) && tracksObj.TryGetProperty("total", out var totalTracks) ? totalTracks.GetInt32() : 0,
                        TrackIds = null
                    });
                }
            }

            return playlists;
        }
    }
}