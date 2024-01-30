using JsonWebToken.Model;
using System.ComponentModel.DataAnnotations;

namespace JsonWebToken.Dto.User
{
    public class UserLoginDto
    {        
        public string userName { get; set; } = string.Empty;               
        public string password { get; set; } = string.Empty;
        
        public Model.User Map(UserDtoAdd userDto)
        {
            Model.User newUser = new Model.User()
            {
                UserName = userDto.userName,                
                Password = userDto.password,                
            };
            return newUser;
        }
    }
}
