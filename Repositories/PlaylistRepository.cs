using Microsoft.EntityFrameworkCore;
using mylastplaylist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mylastplaylist.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {

        private readonly PlaylistDbContext _dbContext;
        public readonly DbSet<Playlist> _dbSet;

        public PlaylistRepository(PlaylistDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Playlist>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Playlist>> GetListOfPlaylistAsync()
        {
            return await _dbContext.Playlists.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistAsync(int userid)
        {
            return await _dbSet.Where(p => p.User.Id == userid).FirstAsync();
        }

        public void AddPlaylist(Playlist newPlaylist)
        {
            _dbSet.Add(newPlaylist);
        }

        public void UpdatePlaylist(Playlist existingPlaylist)
        {
            _dbSet.Attach(existingPlaylist);
        }
    }
}
