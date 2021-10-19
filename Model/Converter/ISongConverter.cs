using mylastplaylist.Model.Dto;

namespace mylastplaylist.Model.Converter
{
    public interface ISongConverter
    {
        Song ConvertSongDtoToSong(SongDto songdto);
        SongDto ConvertSongToSongDto(Song song);
    }
}