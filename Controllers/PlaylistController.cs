using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mylastplaylist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {

        private readonly ILogger<PlaylistController> _logger;

        private readonly IPlaylistService _playlistService;

        public PlaylistController(ILogger<PlaylistController> logger, IPlaylistService playlistService)
        {
            _logger = logger;
            _playlistService = playlistService;
        }

        [HttpGet("/playlists")]
        public async Task<Playlist[]> GetAllPlaylists()
        {
            List<Playlist> Playlists = await _playlistService.GetPlaylists();
            return Playlists.ToArray();
        }

        [HttpGet("/playlists/{id}")]
        public async Task<Playlist> GetPlaylistWithUserId(int id)
        {
            List<Playlist> Playlists = await _playlistService.GetPlaylists();
            return Playlists.Find(p => p.User.Id == id);
        }

        [HttpPost("/playlists/{id}")]
        public async Task<Playlist> PostNewSongToPlaylistWithUserId(int id, Song song)
        {
            Playlist PlaylistWithNewSong = await _playlistService.NewSongToPlaylistWithUserId(id, song);
            return PlaylistWithNewSong;
        }

        [HttpGet("/playlists/users")]
        public async Task<User[]> GetUsersFromPlaylist()
        {
            List<User> Users = await _playlistService.GetUsersFromPlaylists();
            return Users.ToArray();
        }

        [HttpPost("/playlists/users")]
        public async Task<Playlist> NewPlaylist(UserDTO userdto)
        {
            Playlist NewPlaylist = await _playlistService.AddNewPlaylist(userdto);
            return NewPlaylist;
        }
    }
}
