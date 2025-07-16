using System.Threading.Tasks;

public interface ISpotifyPlaybackSdkAdapter
{
    // Playback control
    Task<string> PlayTrackAsync(string trackUri, string accessToken, string deviceId);
    Task<string> PlayContextAsync(string contextUri, string accessToken, string deviceId);
    Task<string> PausePlaybackAsync(string accessToken, string deviceId);
    Task<string> ResumePlaybackAsync(string accessToken, string deviceId);
    Task<string> SkipNextAsync(string accessToken, string deviceId);
    Task<string> SkipPreviousAsync(string accessToken, string deviceId);
    Task<string> SetVolumeAsync(int volumePercent, string accessToken, string deviceId);
    Task<string> SeekAsync(int positionMs, string accessToken, string deviceId);
    Task<string> ShuffleAsync(bool state, string accessToken, string deviceId);
    Task<string> RepeatAsync(string state, string accessToken, string deviceId);
    Task<string> TransferPlaybackAsync(string deviceId, string accessToken);

    // Player state
    Task<string> GetCurrentPlaybackAsync(string accessToken);
    Task<string> GetRecentlyPlayedAsync(string accessToken);

    // Devices
    Task<string> GetAvailableDevicesAsync(string accessToken);
}