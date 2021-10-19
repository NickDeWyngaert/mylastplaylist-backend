using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Data
{
    public class PlaylistDbContext : DbContext
    {
        public PlaylistDbContext(DbContextOptions options) : base (options) { }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
