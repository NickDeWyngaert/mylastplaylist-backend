using System.Collections.Generic;
using System.Threading.Tasks;

namespace mylastplaylist.Repositories
{
    public interface IPlaylistRepository
    {
        void AddPlaylist(Playlist newPlaylist);
        Task<List<Playlist>> GetListOfPlaylistAsync();
        Task<Playlist> GetPlaylistAsync(int userid);
        Task<int> SaveChangesAsync();
        void UpdatePlaylist(Playlist existingPlaylist);
    }
}