using JsonWebToken.Model;

namespace JsonWebToken.Dto
{
    public class PersonGetResponse
    {
        public int id { get; set; }    
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public int age { get; set; }
        public List<PersonGetResponse> Map(List<Person> people)
        {
            List<PersonGetResponse> response = new List<PersonGetResponse>();
            foreach (Person person in people)
            {
                PersonGetResponse personGetAll = new PersonGetResponse()
                {
                    id = person.Id,
                    name = person.Name,
                    age = person.Age,
                    surname = person.Surname,
                    adress = person.Adress,

                };
                response.Add(personGetAll);
            }
            return response;

        }
    }
}
