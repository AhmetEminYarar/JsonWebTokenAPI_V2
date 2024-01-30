using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonWebToken.Model
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Surname { get; set; }=string.Empty;
        public string Adress { get; set; }=string.Empty;
        public int Age { get; set; }
    }
}
