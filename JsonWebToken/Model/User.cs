using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonWebToken.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

    }
}
