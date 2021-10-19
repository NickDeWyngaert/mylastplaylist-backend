using AutoMapper;
using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Model.Converter
{
    public class PlaylistConverter : IPlaylistConverter
    {
        private readonly IMapper _mapper;

        public PlaylistConverter()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.CreateMap<Playlist, PlaylistDto>();
                c.CreateMap<PlaylistDto, Playlist>();
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
    }
}
