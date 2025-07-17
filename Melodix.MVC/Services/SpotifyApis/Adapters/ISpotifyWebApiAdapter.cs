using System.Threading.Tasks;

public interface ISpotifyWebApiAdapter
{
    // Playlists
    Task<string> GetFeaturedPlaylistsAsync(string accessToken);
    Task<string> GetPlaylistAsync(string playlistId, string accessToken);
    Task<string> GetUserPlaylistsAsync(string accessToken);
    Task<string> CreatePlaylistAsync(string userId, string accessToken, string name, string description, bool isPublic);
    Task<string> AddTracksToPlaylistAsync(string playlistId, string[] trackUris, string accessToken);
    Task<string> RemoveTracksFromPlaylistAsync(string playlistId, string[] trackUris, string accessToken);

    // Tracks
    Task<string> GetTrackAsync(string trackId, string accessToken);
    Task<string> GetSeveralTracksAsync(string[] trackIds, string accessToken);
    Task<string> SaveTracksAsync(string[] trackIds, string accessToken);
    Task<string> RemoveSavedTracksAsync(string[] trackIds, string accessToken);

    // Albums
    Task<string> GetAlbumAsync(string albumId, string accessToken);
    Task<string> GetSeveralAlbumsAsync(string[] albumIds, string accessToken);
    Task<string> GetNewReleasesAsync(string accessToken);
    Task<string> SaveAlbumsAsync(string[] albumIds, string accessToken);
    Task<string> RemoveSavedAlbumsAsync(string[] albumIds, string accessToken);

    // Artists
    Task<string> GetArtistAsync(string artistId, string accessToken);
    Task<string> GetSeveralArtistsAsync(string[] artistIds, string accessToken);
    Task<string> GetArtistTopTracksAsync(string artistId, string accessToken);
    Task<string> GetArtistAlbumsAsync(string artistId, string accessToken);
    Task<string> FollowArtistAsync(string artistId, string accessToken);
    Task<string> UnfollowArtistAsync(string artistId, string accessToken);

    // Search
    Task<string> SearchAsync(string query, string type, string accessToken);

    // Categories & Genres
    Task<string> GetCategoriesAsync(string accessToken);
    Task<string> GetCategoryPlaylistsAsync(string categoryId, string accessToken);
    Task<string> GetAvailableGenreSeedsAsync(string accessToken);

    // Recommendations
    Task<string> GetRecommendationsAsync(string accessToken, string seedArtists, string seedGenres, string seedTracks);

    // User Profile
    Task<string> GetCurrentUserProfileAsync(string accessToken);

    // Devices
    Task<string> GetAvailableDevicesAsync(string accessToken);

    // Player State
    Task<string> GetCurrentPlaybackAsync(string accessToken);
    Task<string> GetRecentlyPlayedAsync(string accessToken);

    // Library
    Task<string> GetSavedTracksAsync(string accessToken);
    Task<string> GetSavedAlbumsAsync(string accessToken);

    // Follow Playlist
    Task<string> FollowPlaylistAsync(string playlistId, string accessToken);
    Task<string> UnfollowPlaylistAsync(string playlistId, string accessToken);
}