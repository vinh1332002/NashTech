using assignment3.Models;

namespace assignment3.Services
{
    public class PersonServiceExtended : IPersonService
    {
        private static List<PersonModel> _person = new List<PersonModel>
        {
            new PersonModel()
            {
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                PhoneNumber = "0964083300",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 9, 30),
                PhoneNumber = "0985483300",
                BirthPlace = "ha noi",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Ngai",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 5, 30),
                PhoneNumber = "0875463300",
                BirthPlace = "Thai Binh",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Chuoi",
                LastName = "Le",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 4, 24),
                PhoneNumber = "0185683001",
                BirthPlace = "Quang Ngai",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Than",
                LastName = "Dang",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 10, 10),
                PhoneNumber = "0285483780",
                BirthPlace = "Thai Nguyen",
                IsGraduated = true
            }
        };

        public List<PersonModel> GetAll()
        {
            return _person;
        }

        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                return _person[index];
            }
            return null;
        }

        public PersonModel Create(PersonModel model)
        {
            _person.Add(model);
            return model;
        }

        public PersonModel? Update(int index, PersonModel model)
        {
            if (index >= 0 && index < _person.Count)
            {
                _person[index] = model;
                return model;
            }
            return null;
        }

        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                var person = _person[index];
                _person.RemoveAt(index);
                return person;
            }

            return null;
        }
    }
}