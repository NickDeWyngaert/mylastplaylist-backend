using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Model.Dto
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public List<SongDto> Songs { get; set; }
    }
}
