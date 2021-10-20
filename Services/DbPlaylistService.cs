using mylastplaylist.Model.Converter;
using mylastplaylist.Model.Dto;
using mylastplaylist.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public class DbPlaylistService : IPlaylistService
    {

        private readonly IPlaylistRepository _repository;
        private readonly IConverter _converter;

        public DbPlaylistService(IPlaylistRepository repository, IConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public async Task<List<PlaylistDto>> GetListOfPlaylists()
        {
            List<Playlist> playlists = await _repository.GetListOfPlaylistAsync();
            return _converter.ConvertListPlaylistToDto(playlists);
        }

        public async Task<List<UserDto>> GetUsersListFromPlaylists()
        {
            List<Playlist> playlists = await _repository.GetListOfPlaylistAsync();
            List<User> usersOfPlaylists = new List<User>();
            foreach(Playlist playlist in playlists) { usersOfPlaylists.Add(playlist.User); }
            return _converter.ConvertListUserToDto(usersOfPlaylists);
        }
        
        public async Task<PlaylistDto> GetPlaylistFromUser(int userid)
        {
            Playlist playlist = await _repository.GetPlaylistAsync(userid);
            return _converter.ConvertPlaylistToPlaylistDto(playlist);
        }

        public async Task<PlaylistDto> NewPlaylist(UserDto newuserdto)
        {
            PlaylistDto newPlaylistDto = new PlaylistDto() { User= newuserdto, Songs=new List<SongDto>() };
            Playlist newPlaylist = _converter.ConvertPlaylistDtoToPlaylist(newPlaylistDto);
            _repository.AddPlaylist(newPlaylist);
            await _repository.SaveChangesAsync();
            return newPlaylistDto;
        }

        public async Task<PlaylistDto> NewSongToPlaylistWithUserId(int userid, SongDto newsongdto)
        {
            Playlist existingPlaylist = await _repository.GetPlaylistAsync(userid);
            existingPlaylist.Songs.Add(_converter.ConvertSongDtoToSong(newsongdto));
            _repository.UpdatePlaylist(existingPlaylist);
            await _repository.SaveChangesAsync();
            return _converter.ConvertPlaylistToPlaylistDto(existingPlaylist);
        }
    }
}
