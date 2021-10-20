using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist
{
    public class Playlist
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }
    }
}
