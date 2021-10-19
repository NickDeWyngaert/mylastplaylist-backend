using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Services
{
    public class PlaylistService : IPlaylistService
    {

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

        public Task<List<Playlist>> GetPlaylists()
        {
            return Task.FromResult(Playlists);
        }

        public Task<List<User>> GetUsersFromPlaylists()
        {
            List<User> Users = new List<User>();
            foreach(Playlist Playlist in Playlists) Users.Add(Playlist.User);
            return Task.FromResult(Users);
        }

        public Task<Playlist> NewSongToPlaylistWithUserId(int id, Song newsong)
        {
            Playlist PlaylistFromUser = Playlists[Playlists.FindIndex(p => p.User.Id == id)];
            PlaylistFromUser.Songs.Add(newsong);
            Playlists[Playlists.FindIndex(p => p.User.Id == id)] = PlaylistFromUser;
            return Task.FromResult(PlaylistFromUser);
        }

        public Task<Playlist> NewUserWithPlaylist(UserDTO userdto)
        {
            Random rnd = new Random();
            User NewUser = new User() { Id = rnd.Next(1, 200), LastName = userdto.lastname, FirstName = userdto.firstname };
            Playlist NewPlaylistWithNewUser = new Playlist() {
                User = NewUser,
                Songs = new List<Song>() {}
            };
            Playlists.Add(NewPlaylistWithNewUser);
            return Task.FromResult(NewPlaylistWithNewUser);
        }
    }
}
