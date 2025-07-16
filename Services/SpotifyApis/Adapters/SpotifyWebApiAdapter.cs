using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class SpotifyWebApiAdapter:ISpotifyWebApiAdapter
{
    private readonly HttpClient _httpClient;

    public SpotifyWebApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private void SetAuth(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<string> GetFeaturedPlaylistsAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/browse/featured-playlists");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetPopularAlbumsAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/browse/new-releases");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetArtistTopTracksAsync(string artistId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{artistId}/top-tracks?market=US");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetPlaylistAsync(string playlistId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/playlists/{playlistId}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetUserPlaylistsAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/me/playlists");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetTrackAsync(string trackId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/tracks/{trackId}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SearchAsync(string query, string type, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/search?q={query}&type={type}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetCategoriesAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/browse/categories");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetCategoryPlaylistsAsync(string categoryId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/browse/categories/{categoryId}/playlists");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetNewReleasesAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/browse/new-releases");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetAlbumAsync(string albumId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/albums/{albumId}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetArtistAsync(string artistId, string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{artistId}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetRecommendationsAsync(string accessToken, string seedArtists, string seedGenres, string seedTracks)
    {
        SetAuth(accessToken);
        var url = $"https://api.spotify.com/v1/recommendations?seed_artists={seedArtists}&seed_genres={seedGenres}&seed_tracks={seedTracks}";
        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}