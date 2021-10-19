using AutoMapper;
using mylastplaylist.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist.Model.Converter
{
    public class UserConverter : IUserConverter
    {
        private readonly IMapper _mapper;

        public UserConverter()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDto>();
                c.CreateMap<UserDto, User>();
            });
            _mapper = config.CreateMapper();
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
    }
}
