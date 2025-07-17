using System.Threading.Tasks;

public interface ISpotifyService
{
    // Ejemplo de métodos de alto nivel que combinan/adaptan los adapters
    Task<string> GetHomeDataAsync(string accessToken);
    Task<string> SearchAllAsync(string query, string accessToken);
    Task<string> PlayTrackAsync(string trackUri, string accessToken, string deviceId);
    Task<string> GetUserProfileAsync(string accessToken);
    // Puedes agregar más métodos según la lógica de tu app
}