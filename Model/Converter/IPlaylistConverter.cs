using mylastplaylist.Model.Dto;

namespace mylastplaylist.Model.Converter
{
    public interface IPlaylistConverter
    {
        Playlist ConvertPlaylistDtoToPlaylist(PlaylistDto playlistdto);
        PlaylistDto ConvertPlaylistToPlaylistDto(Playlist playlist);
    }
}