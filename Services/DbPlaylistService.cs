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

        public async Task<PlaylistDto> NewPlaylist(UserDto newUserdto)
        {
            PlaylistDto newPlaylistDto = new PlaylistDto() { User= newUserdto, Songs=new List<SongDto>() };
            Playlist newPlaylist = _converter.ConvertPlaylistDtoToPlaylist(newPlaylistDto);
            _repository.AddPlaylist(newPlaylist);
            await _repository.SaveChangesAsync();
            return newPlaylistDto;
        }

        public async Task<PlaylistDto> NewSongToPlaylistWithUserId(int userid, SongDto newsongdto)
        {
            Playlist existingPlaylist = await _repository.GetPlaylistAsync(userid);
            if (existingPlaylist.Songs == null) existingPlaylist.Songs = new List<Song>();
            Song newsong = _converter.ConvertSongDtoToSong(newsongdto);
            existingPlaylist.AddSong(newsong);
            _repository.UpdatePlaylist(existingPlaylist);
            await _repository.SaveChangesAsync();
            return _converter.ConvertPlaylistToPlaylistDto(existingPlaylist);
        }

        public async Task<List<SongDto>> GetSongsFromPlaylistUser(int userid)
        {
            Playlist existingPlaylist = await _repository.GetPlaylistAsync(userid);
            List<Song> songsFromExistingPlaylist = existingPlaylist.Songs;
            return _converter.ConvertListSongToDto(songsFromExistingPlaylist);
        }
    }
}
