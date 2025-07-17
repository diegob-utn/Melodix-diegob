using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

public static class SpotifyAuthHelper
{
    public static async Task<string> GetAccessTokenAsync(string clientId, string clientSecret)
    {
        using var client = new HttpClient();
        var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

        var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
        request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();

        // Extrae el access_token del JSON (puedes usar System.Text.Json para deserializar)
        using var doc = System.Text.Json.JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("access_token").GetString();
    }
}