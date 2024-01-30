using JsonWebToken.Model;

namespace JsonWebToken.Dto
{
    public class PersonAddRequest
    {
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public int age { get; set; }
        public Person Map(PersonAddRequest person)
        {
            Person newPerson = new Person()
            {
                Name = person.name,
                Surname = person.surname,
                Age = person.age,
                Adress = person.adress,
            };
            return newPerson;
        }
    }
}
