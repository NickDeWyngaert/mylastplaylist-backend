using mylastplaylist.Model.Dto;

namespace mylastplaylist.Model.Converter
{
    public interface IUserConverter
    {
        User ConvertUserDtoToUser(UserDto userdto);
        UserDto ConvertUserToUserDto(User user);
    }
}