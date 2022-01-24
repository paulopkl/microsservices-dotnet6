using RestWithASPNET.Controllers.Model;

namespace RestWithASPNET.Controllers.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                persons.Add(
                    new Person()
                    {
                        Id = i,
                        FirstName = "Person FirstName",
                        LastName = "Person LastName",
                        Address = "Sumaré - SP, Brasil",
                        Gender = "Male"
                    }
                );
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person() 
            { 
                Id = 1,
                FirstName = "Paulo",
                LastName = "Almeida",
                Address = "Sumaré - SP, Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
