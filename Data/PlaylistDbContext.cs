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

        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

    }
}
