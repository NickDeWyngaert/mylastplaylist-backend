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

        private readonly IPlaylistService _playlistService;

        public PlaylistsController(ILogger<PlaylistsController> logger, IConfiguration configration, IPlaylistService playlistService)
        {
            _logger = logger;
            _configration = configration;
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<PlaylistDto[]> GetAllPlaylists()
        {
            List<PlaylistDto> Playlists = await _playlistService.GetListOfPlaylists();
            return Playlists.ToArray();
        }
        
        [HttpPost]
        public async Task<PlaylistDto> NewPlaylistWithNewUser(UserDto userdto)
        {
            PlaylistDto NewPlaylist = await _playlistService.NewPlaylist(userdto);
            return NewPlaylist;
        }

        [HttpGet("{id}")]
        public async Task<PlaylistDto> GetPlaylistWithUserId(int id)
        {
            PlaylistDto Playlist = await _playlistService.GetPlaylistFromUser(id);
            return Playlist;
        }

        [HttpPost("{id}/songs")]
        public async Task<PlaylistDto> PostNewSongToPlaylistWithUserId(int id, SongDto song)
        {
            PlaylistDto PlaylistWithNewSong = await _playlistService.NewSongToPlaylistWithUserId(id, song);
            return PlaylistWithNewSong;
        }

        [HttpGet("users")]
        public async Task<UserDto[]> GetUsersFromPlaylist()
        {
            List<UserDto> Users = await _playlistService.GetUsersListFromPlaylists();
            return Users.ToArray();
        }
    }
}
