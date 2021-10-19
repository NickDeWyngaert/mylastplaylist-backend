using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public interface IService
    {
        Task<List<Playlist>> GetPlaylists();
        Task<List<User>> GetUsersFromPlaylists();
        Task<Playlist> NewSongToPlaylistWithUserId(int id, Song newsong);
        Task<Playlist> NewUserWithPlaylist(UserDTO userdto);
    }
}
