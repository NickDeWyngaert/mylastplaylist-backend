using mylastplaylist.Model.Dto;
using System.Collections.Generic;

namespace mylastplaylist.Model.Converter
{
    public interface IConverter
    {
        List<PlaylistDto> ConvertListPlaylistToDto(List<Playlist> playlists);
        List<SongDto> ConvertListSongToDto(List<Song> songs);
        List<UserDto> ConvertListUserToDto(List<User> users);
        Playlist ConvertPlaylistDtoToPlaylist(PlaylistDto playlistdto);
        PlaylistDto ConvertPlaylistToPlaylistDto(Playlist playlist);
        Song ConvertSongDtoToSong(SongDto songdto);
        SongDto ConvertSongToSongDto(Song song);
        User ConvertUserDtoToUser(UserDto userdto);
        UserDto ConvertUserToUserDto(User user);
    }
}