using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class SpotifyPlaybackSdkAdapter:ISpotifyPlaybackSdkAdapter
{
    private readonly HttpClient _httpClient;

    public SpotifyPlaybackSdkAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private void SetAuth(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<string> PlayTrackAsync(string trackUri, string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var body = $"{{\"uris\": [\"{trackUri}\"], \"device_id\": \"{deviceId}\"}}";
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("https://api.spotify.com/v1/me/player/play", content);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PausePlaybackAsync(string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var response = await _httpClient.PutAsync($"https://api.spotify.com/v1/me/player/pause?device_id={deviceId}", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> ResumePlaybackAsync(string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var response = await _httpClient.PutAsync($"https://api.spotify.com/v1/me/player/play?device_id={deviceId}", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SkipNextAsync(string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var response = await _httpClient.PostAsync($"https://api.spotify.com/v1/me/player/next?device_id={deviceId}", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SkipPreviousAsync(string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var response = await _httpClient.PostAsync($"https://api.spotify.com/v1/me/player/previous?device_id={deviceId}", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SetVolumeAsync(int volumePercent, string accessToken, string deviceId)
    {
        SetAuth(accessToken);
        var response = await _httpClient.PutAsync($"https://api.spotify.com/v1/me/player/volume?volume_percent={volumePercent}&device_id={deviceId}", null);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetCurrentPlaybackAsync(string accessToken)
    {
        SetAuth(accessToken);
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/me/player");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> TransferPlaybackAsync(string deviceId, string accessToken)
    {
        SetAuth(accessToken);
        var body = $"{{\"device_ids\": [\"{deviceId}\"], \"play\": true}}";
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("https://api.spotify.com/v1/me/player", content);
        return await response.Content.ReadAsStringAsync();
    }
}