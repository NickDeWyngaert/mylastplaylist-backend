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
    public class PlaylistController : ControllerBase
    {

        private readonly ILogger<PlaylistController> _logger;

        private readonly IConfiguration _configration;

        private readonly IService _playlistService;

        public PlaylistController(ILogger<PlaylistController> logger, IConfiguration configration, IService playlistService)
        {
            _logger = logger;
            _configration = configration;
            _playlistService = playlistService;
        }

        [HttpGet("/playlists")]
        public async Task<Playlist[]> GetAllPlaylists()
        {
            List<Playlist> Playlists = await _playlistService.GetPlaylists();
            return Playlists.ToArray();
        }
        
        [HttpPost("/playlists")]
        public async Task<Playlist> NewPlaylistWithNewUser(UserDto userdto)
        {
            Playlist NewPlaylist = await _playlistService.NewUserWithPlaylist(userdto);
            return NewPlaylist;
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

        
    }
}
