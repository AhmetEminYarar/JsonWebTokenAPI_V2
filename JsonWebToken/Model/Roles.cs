using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonWebToken.Model
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rolename { get; set; } = string.Empty;
        public ICollection<User> Users { get; } = new List<User>();

    }
}
