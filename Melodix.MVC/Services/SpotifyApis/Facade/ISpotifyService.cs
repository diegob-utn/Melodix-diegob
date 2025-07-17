using System.Threading.Tasks;

public interface ISpotifyService
{
    // Ejemplo de m�todos de alto nivel que combinan/adaptan los adapters
    Task<string> GetHomeDataAsync(string accessToken);
    Task<string> SearchAllAsync(string query, string accessToken);
    Task<string> PlayTrackAsync(string trackUri, string accessToken, string deviceId);
    Task<string> GetUserProfileAsync(string accessToken);
    // Puedes agregar m�s m�todos seg�n la l�gica de tu app
}