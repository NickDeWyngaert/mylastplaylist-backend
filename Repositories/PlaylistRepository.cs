using Microsoft.EntityFrameworkCore;
using mylastplaylist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Repositories
{
    public class PlaylistRepository
    {

        private readonly PlaylistDbContext _playlistDbContext;
        public readonly DbSet<Playlist> _dbSet;

        public PlaylistRepository(PlaylistDbContext playlistcontext)
        {
            _playlistDbContext = playlistcontext;
            _dbSet = _playlistDbContext.Set<Playlist>();
        }
        


    }
}
