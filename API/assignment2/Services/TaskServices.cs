using assignment2.Models;
using assignment2.Filter;

namespace assignment2.Services
{
    public class TaskServices : ITaskServices
    {
        private static List<NewTaskRequestModel> _person = new List<NewTaskRequestModel>
        {
            new NewTaskRequestModel()
            {
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                BirthPlace = "Ha Noi"
            },
            new NewTaskRequestModel()
            {
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 9, 30),
                BirthPlace = "ha noi"
            },
            new NewTaskRequestModel()
            {
                FirstName = "Ngai",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 5, 30),
                BirthPlace = "Thai Binh"
            },
            new NewTaskRequestModel()
            {
                FirstName = "Chuoi",
                LastName = "Le",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 4, 24),
                BirthPlace = "Quang Ngai"
            },
            new NewTaskRequestModel()
            {
                FirstName = "Than",
                LastName = "Dang",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 10, 10),
                BirthPlace = "Thai Nguyen"
            }
        };

        public List<NewTaskRequestModel> GetAll()
        {
            return _person;
        }

        public NewTaskRequestModel? GetOne(Guid index)
        {
            return _person.SingleOrDefault(p => p.UniqueId.Equals(index));
        }

        public NewTaskRequestModel Create(NewTaskRequestModel model)
        {
            _person.Add(model);

            return model;
        }

        public NewTaskRequestModel? Update(Guid index, NewTaskRequestModel model)
        {
            var data = _person.FindIndex(p => p.UniqueId.Equals(index));
            if (data >= 0)
            {
                _person[data] = model;
                return _person[data];
            }
            return null;
        }

        public NewTaskRequestModel? Delete(Guid index)
        {
            var data = _person.FindIndex(p => p.UniqueId.Equals(index));

            if (data >= 0)
            {
                _person.RemoveAt(data);
                return _person[data];
            }
            return null;
        }

        public IEnumerable<NewTaskRequestModel> GetPagnition(OwnerParameters ownerParameters)
        {
            return GetAll()
                .OrderBy(on => on.FirstName)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToList();
        }

        public List<NewTaskRequestModel> FilterList(string firstName, string lastName, string gender, string birthPlace){
            var filter = _person
            .Where(f => f.FirstName == firstName)
            .Where(l => l.LastName == lastName)
            .Where(g => g.Gender.ToLower().Trim() == gender.ToLower().Trim())
            .Where(b => b.BirthPlace.ToLower().Trim() == birthPlace.ToLower().Trim());

            return filter.ToList();
        }
    }
}