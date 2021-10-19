using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mylastplaylist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using mylastplaylist.Model.Dto;

namespace mylastplaylist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PlaylistsController : ControllerBase
    {

        private readonly ILogger<PlaylistsController> _logger;

        private readonly IConfiguration _configration;

        private readonly IService _playlistService;

        public PlaylistsController(ILogger<PlaylistsController> logger, IConfiguration configration, IService playlistService)
        {
            _logger = logger;
            _configration = configration;
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<Playlist[]> GetAllPlaylists()
        {
            List<Playlist> Playlists = await _playlistService.GetPlaylists();
            return Playlists.ToArray();
        }
        
        [HttpPost]
        public async Task<Playlist> NewPlaylistWithNewUser(UserDto userdto)
        {
            Playlist NewPlaylist = await _playlistService.NewUserWithPlaylist(userdto);
            return NewPlaylist;
        }

        [HttpGet("{id}")]
        public async Task<Playlist> GetPlaylistWithUserId(int id)
        {
            List<Playlist> Playlists = await _playlistService.GetPlaylists();
            return Playlists.Find(p => p.User.Id == id);
        }

        [HttpPost("{id}/songs")]
        public async Task<Playlist> PostNewSongToPlaylistWithUserId(int id, Song song)
        {
            Playlist PlaylistWithNewSong = await _playlistService.NewSongToPlaylistWithUserId(id, song);
            return PlaylistWithNewSong;
        }

        [HttpGet("users")]
        public async Task<User[]> GetUsersFromPlaylist()
        {
            List<User> Users = await _playlistService.GetUsersFromPlaylists();
            return Users.ToArray();
        }

        
    }
}
