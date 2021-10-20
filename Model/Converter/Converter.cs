using AutoMapper;
using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Model.Converter
{
    public class Converter : IConverter
    {
        private readonly IMapper _mapper;

        public Converter()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.CreateMap<Playlist, PlaylistDto>().ForMember(dest => dest.User, opt => opt.MapFrom(x => x.User));
                c.CreateMap<PlaylistDto, Playlist>();/*.ForMember(dest => dest.UserDto, opt => opt.MapFrom(x => x.User));*/
                c.CreateMap<User, UserDto>();
                c.CreateMap<UserDto, User>();
                c.CreateMap<Song, SongDto>();
                c.CreateMap<SongDto, Song>();

            });
            _mapper = config.CreateMapper();
        }

        // PlaylistDto -> Playlist
        public PlaylistDto ConvertPlaylistToPlaylistDto(Playlist playlist)
        {
            return _mapper.Map<Playlist, PlaylistDto>(playlist);
        }

        // Playlist -> PlaylistDto
        public Playlist ConvertPlaylistDtoToPlaylist(PlaylistDto playlistdto)
        {
            return _mapper.Map<PlaylistDto, Playlist>(playlistdto);
        }

        // List<Playlist> -> List<PlaylistDto>
        public List<PlaylistDto> ConvertListPlaylistToDto(List<Playlist> playlists)
        {
            return _mapper.Map<List<PlaylistDto>>(playlists);
        }

        // List<Song> -> List<SongDto>
        public List<SongDto> ConvertListSongDtoToDto(List<Song> songs)
        {
            return _mapper.Map<List<SongDto>>(songs);
        }

        // Song -> SongDto
        public SongDto ConvertSongToSongDto(Song song)
        {
            return _mapper.Map<Song, SongDto>(song);
        }

        // SongDto -> Song
        public Song ConvertSongDtoToSong(SongDto songdto)
        {
            return _mapper.Map<SongDto, Song>(songdto);
        }

        // UserDto -> User
        public UserDto ConvertUserToUserDto(User user)
        {
            return _mapper.Map<User, UserDto>(user);
        }

        // User -> UserDto
        public User ConvertUserDtoToUser(UserDto userdto)
        {
            return _mapper.Map<UserDto, User>(userdto);
        }

        // List<User> -> List<UserDto>
        public List<UserDto> ConvertListUserToDto(List<User> users)
        {
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
