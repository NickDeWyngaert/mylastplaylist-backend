using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mylastplaylist.Data
{
    public class PlaylistDbContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }

        public PlaylistDbContext(DbContextOptions options) : base(options) { }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return base.SaveChangesAsync(cancellation);
        }

    }
}
