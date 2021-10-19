using Microsoft.EntityFrameworkCore;
using mylastplaylist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Repositories
{
    public class SongRepository
    {
        private readonly PlaylistDbContext _playlistDbContext;
        public readonly DbSet<Song> _dbSet;

        public SongRepository(PlaylistDbContext playlistcontext)
        {
            _playlistDbContext = playlistcontext;
            _dbSet = _playlistDbContext.Set<Song>();
        }

    }
}
