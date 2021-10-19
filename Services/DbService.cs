using mylastplaylist.Model.Dto;
using mylastplaylist.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public class DbService : IService
    {

        private readonly PlaylistRepository _repository;

        public DbService(PlaylistRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Playlist>> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersFromPlaylists()
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> NewSongToPlaylistWithUserId(int id, Song newsong)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> NewUserWithPlaylist(UserDto userdto)
        {
            throw new NotImplementedException();
        }
    }
}
