using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public interface IPlaylistService
    {
        Task<List<PlaylistDto>> GetListOfPlaylists();
        Task<List<UserDto>> GetUsersListFromPlaylists();
        Task<PlaylistDto> GetPlaylistFromUser(int userid);
        Task<PlaylistDto> NewSongToPlaylistWithUserId(int userid, SongDto newsongdto);
        Task<PlaylistDto> NewPlaylist(UserDto newuserdto);
    }
}
