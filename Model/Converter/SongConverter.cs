using AutoMapper;
using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Model.Converter
{
    public class SongConverter : ISongConverter
    {
        private readonly IMapper _mapper;

        public SongConverter()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.CreateMap<Song, SongDto>();
                c.CreateMap<SongDto, Song>();
            });
            _mapper = config.CreateMapper();
        }

        // SongDto -> Song
        public SongDto ConvertSongToSongDto(Song song)
        {
            return _mapper.Map<Song, SongDto>(song);
        }

        // Song -> Dto
        public Song ConvertSongDtoToSong(SongDto songdto)
        {
            return _mapper.Map<SongDto, Song>(songdto);
        }
    }
}
