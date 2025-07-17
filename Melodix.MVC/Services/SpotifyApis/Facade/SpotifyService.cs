using System.Threading.Tasks;

public class SpotifyService : ISpotifyService
{
    private readonly ISpotifyWebApiAdapter _webApiAdapter;
    private readonly ISpotifyPlaybackSdkAdapter _playbackAdapter;
    private readonly ISpotifyAdsApiAdapter _adsAdapter;

    public SpotifyService(
        ISpotifyWebApiAdapter webApiAdapter,
        ISpotifyPlaybackSdkAdapter playbackAdapter,
        ISpotifyAdsApiAdapter adsAdapter)
    {
        _webApiAdapter = webApiAdapter;
        _playbackAdapter = playbackAdapter;
        _adsAdapter = adsAdapter;
    }

    public async Task<string> GetHomeDataAsync(string accessToken)
    {
        // Ejemplo: Combina playlists, álbumes y recomendaciones
        var playlists = await _webApiAdapter.GetFeaturedPlaylistsAsync(accessToken);
        var albums = await _webApiAdapter.GetNewReleasesAsync(accessToken);
        var recommendations = await _webApiAdapter.GetRecommendationsAsync(accessToken, "", "", "");
        // Puedes combinar los resultados en un solo objeto/JSON
        return $"{{\"playlists\":{playlists},\"albums\":{albums},\"recommendations\":{recommendations}}}";
    }

    public async Task<string> SearchAllAsync(string query, string accessToken)
    {
        // Ejemplo: Busca en todos los tipos
        var result = await _webApiAdapter.SearchAsync(query, "album,artist,playlist,track", accessToken);
        return result;
    }

    public async Task<string> PlayTrackAsync(string trackUri, string accessToken, string deviceId)
    {
        return await _playbackAdapter.PlayTrackAsync(trackUri, accessToken, deviceId);
    }

    public async Task<string> GetUserProfileAsync(string accessToken)
    {
        return await _webApiAdapter.GetCurrentUserProfileAsync(accessToken);
    }

    // Puedes agregar más métodos que combinen/adapten los adapters según la lógica de tu app
}