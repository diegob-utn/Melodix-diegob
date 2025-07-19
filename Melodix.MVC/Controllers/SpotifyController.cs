using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Melodix.MVC.Services.SpotifyApis;

namespace Melodix.MVC.Controllers
{
    // Controlador para autenticación y reproducción con Spotify
    [Route("Spotify")]
    [Authorize]
    public class SpotifyController : Controller
    {
        private readonly ILogger<SpotifyController> _logger;
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ILogger<SpotifyController> logger, ISpotifyService spotifyService)
        {
            _logger = logger;
            _spotifyService = spotifyService;
        }

        [HttpPost("play")]
        public async Task<IActionResult> Play([FromBody] PlayRequest request)
        {
            if (string.IsNullOrEmpty(request.TrackUri) || string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.DeviceId))
                return BadRequest("Faltan datos requeridos.");

            var result = await _spotifyService.PlayTrackAsync(request.TrackUri, request.AccessToken, request.DeviceId);
            return Ok(result);
        }

        public class PlayRequest
        {
            public string? TrackUri { get; set; }
            public string? AccessToken { get; set; }
            public string? DeviceId { get; set; }
        }


        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            // Inicia el flujo OAuth de Spotify
            var redirectUrl = "https://localhost:5001/callback";
            return Challenge(new AuthenticationProperties { RedirectUri = redirectUrl }, "Spotify");
        }

        [HttpGet("/callback")]
        [AllowAnonymous]
        public IActionResult Callback(string returnUrl = "/")
        {
            // Aquí puedes manejar el token si necesitas lógica extra
            return LocalRedirect(returnUrl);
        }



    }
}