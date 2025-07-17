using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class SpotifyAdsApiAdapter:ISpotifyAdsApiAdapter
{
    private readonly HttpClient _httpClient;

    public SpotifyAdsApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private void SetAuth(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<string> GetAdsAsync(string accessToken)
    {
        SetAuth(accessToken);
        // Ejemplo de endpoint, reemplaza por el real de la Ads API
        var response = await _httpClient.GetAsync("https://api.spotify.com/v1/ads");
        return await response.Content.ReadAsStringAsync();
    }

    public Task<string> CreateAdAsync(string accessToken, string adContent)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetAdStatsAsync(string accessToken, string adId)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateAdAsync(string accessToken, string adId, string adContent)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAdAsync(string accessToken, string adId)
    {
        throw new NotImplementedException();
    }

    // Agrega más métodos aquí según lo que permita la Ads API
}