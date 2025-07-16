using System.Threading.Tasks;

public interface ISpotifyAdsApiAdapter
{
    // Nota: La Ads API de Spotify es privada y limitada. Ejemplo de métodos posibles:
    Task<string> GetAdsAsync(string accessToken);
    Task<string> CreateAdAsync(string accessToken, string adContent);
    Task<string> GetAdStatsAsync(string accessToken, string adId);
    Task<string> UpdateAdAsync(string accessToken, string adId, string adContent);
    Task<string> DeleteAdAsync(string accessToken, string adId);
    // Agrega más métodos según lo que permita la Ads API y tu acceso
}