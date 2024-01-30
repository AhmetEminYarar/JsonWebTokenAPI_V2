using JsonWebToken.Model;
using System.ComponentModel.DataAnnotations;

namespace JsonWebToken.Dto.User
{
    public class UserDtoAdd
    {
        [Required]
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required]
        public int roleId { get; set; }
        public Model.User Map(UserDtoAdd userDto)
        {
            Model.User newUser = new Model.User()
            {
                UserName = userDto.userName,
                Email = userDto.email,
                Password = userDto.password,
                RoleId = userDto.roleId,
            };
            return newUser;
        }
    }
}
