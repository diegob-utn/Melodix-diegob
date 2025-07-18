let spotifyPlayer;
let deviceId = null;

window.onSpotifyWebPlaybackSDKReady = () => {
  // Obtén el token desde window global
  const userAccessToken = window.spotifyAccessToken;

  spotifyPlayer = new Spotify.Player({
    name: 'Melodix Player',
    getOAuthToken: cb => { cb(userAccessToken); }
  });

  spotifyPlayer.addListener('ready', ({ device_id }) => {
    deviceId = device_id;
    // Habilita los botones play
    document.querySelectorAll('.btn-play').forEach(btn => btn.disabled = false);
    console.log('Ready with Device ID', device_id);
  });

  spotifyPlayer.addListener('not_ready', ({ device_id }) => {
    deviceId = null;
    document.querySelectorAll('.btn-play').forEach(btn => btn.disabled = true);
    console.log('Device ID has gone offline', device_id);
  });

  spotifyPlayer.connect();
};

// Deshabilita los botones hasta que el reproductor esté listo
document.addEventListener('DOMContentLoaded', function () {
  document.querySelectorAll('.btn-play').forEach(btn => btn.disabled = true);
  document.querySelectorAll('.btn-play').forEach(function (btn) {
    btn.addEventListener('click', function () {
      const uri = btn.getAttribute('data-uri');
      const userAccessToken = window.spotifyAccessToken;
      if (!deviceId || !userAccessToken || !spotifyPlayer) {
        alert('Player no inicializado o falta token.');
        return;
      }
      fetch(`https://api.spotify.com/v1/me/player/play?device_id=${deviceId}`, {
        method: 'PUT',
        body: JSON.stringify({ uris: [uri] }),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${userAccessToken}`
        }
      });
    });
  });
});