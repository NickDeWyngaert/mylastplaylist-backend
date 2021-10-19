using mylastplaylist.Model.Converter;
using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public class MemoryPlaylistService : IPlaylistService
    {
        private readonly IConverter _converter;
        private List<Playlist> Playlists = new List<Playlist>() { 
            new Playlist() { 
                User = new User(){ Id = 1, FirstName = "Nick", LastName = "De Wyngaert", DayOfBirth = new DateTime(2000, 9, 13) },
                Songs = new List<Song>() {
                    new Song() { Title = "Billie Jean", Artist = "Michael Jackson", Link = "Link1" },
                    new Song() { Title = "Bohemian Rhapsody ", Artist = "Queen", Link = "Link2" },
                    new Song() { Title = "Like A Rolling Stone", Artist = "Bob Dylan", Link = "Link3" }
                }
            },
            new Playlist() {
                User = new User() { Id = 2, FirstName = "Kevin", LastName = "De Rudder", DayOfBirth = new DateTime(2000, 9, 13) },
                Songs = new List<Song>() {
                    new Song() { Title = "Title1", Artist = "Artist1", Link = "Link1" },
                    new Song() { Title = "Title2", Artist = "Artist2", Link = "Link2" },
                    new Song() { Title = "Title3", Artist = "Artist3", Link = "Link3" }
                }
            },
        };

        public MemoryPlaylistService(IConverter converter)
        {
            _converter = converter;
        }

        public Task<List<PlaylistDto>> GetListOfPlaylists()
        {
            List<PlaylistDto> listPlaylistDtos = _converter.ConvertListPlaylistToDto(Playlists);
            return Task.FromResult(listPlaylistDtos);
        }

        public Task<List<UserDto>> GetUsersListFromPlaylists()
        {
            List<User> usersOfPlaylists = new List<User>();
            foreach (Playlist playlist in Playlists) { usersOfPlaylists.Add(playlist.User); }
            return Task.FromResult(_converter.ConvertListUserToDto(usersOfPlaylists));
        }

        public Task<PlaylistDto> GetPlaylistFromUser(int userid)
        {
            Playlist PlaylistFromUser = Playlists[Playlists.FindIndex(p => p.User.Id == userid)];
            return Task.FromResult(_converter.ConvertPlaylistToPlaylistDto(PlaylistFromUser));
        }

        public Task<PlaylistDto> NewSongToPlaylistWithUserId(int userid, SongDto newsongdto)
        {
            Playlist PlaylistFromUser = Playlists[Playlists.FindIndex(p => p.User.Id == userid)];
            PlaylistFromUser.Songs.Add(_converter.ConvertSongDtoToSong(newsongdto));
            Playlists[Playlists.FindIndex(p => p.User.Id == userid)] = PlaylistFromUser;
            return Task.FromResult(_converter.ConvertPlaylistToPlaylistDto(PlaylistFromUser));
        }

        public Task<PlaylistDto> NewPlaylist(UserDto newuserdto)
        {
            User NewUser = new User() { Id = new Random().Next(1, 1000), LastName = newuserdto.LastName, FirstName = newuserdto.FirstName };
            Playlist NewPlaylistWithNewUser = new Playlist()
            {
                User = NewUser,
                Songs = new List<Song>() { }
            };
            Playlists.Add(NewPlaylistWithNewUser);
            return Task.FromResult(_converter.ConvertPlaylistToPlaylistDto(NewPlaylistWithNewUser));
        }
    }
}
