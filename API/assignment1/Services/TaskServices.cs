using assignment1.Models.RequestModels;

namespace assignment1.Services
{
    public class TaskServices : ITaskServices
    {
        private static List<NewTaskRequestModel> _person = new List<NewTaskRequestModel>
        {
            new NewTaskRequestModel()
            {
                Title = "Vinh",
                IsCompleted = true
            },
            new NewTaskRequestModel()
            {
                Title = "Tu",
                IsCompleted = true
            },
            new NewTaskRequestModel()
            {
                Title = "Duc",
                IsCompleted = false
            },
            new NewTaskRequestModel()
            {
                Title = "Chuoi",
                IsCompleted = true
            },
            new NewTaskRequestModel()
            {
                Title = "Ca",
                IsCompleted = false
            },
            new NewTaskRequestModel()
            {
                Title = "Nai",
                IsCompleted = true
            },
            new NewTaskRequestModel()
            {
                Title = "Beo",
                IsCompleted = false
            },
            new NewTaskRequestModel()
            {
                Title = "Von",
                IsCompleted = true
            }
        };

        public List<NewTaskRequestModel> GetAll()
        {
            return _person;
        }

        public NewTaskRequestModel? GetOne(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                return _person[index];
            }
            return null;
        }

        public NewTaskRequestModel Create(NewTaskRequestModel model)
        {
            _person.Add(model);

            return model;
        }

        public NewTaskRequestModel? Update(int index, NewTaskRequestModel model)
        {
            if (index >= 0 && index < _person.Count)
            {
                _person[index] = model;

                return model;
            }
            return null;
        }

        public NewTaskRequestModel? Delete(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                var person = _person[index];

                _person.RemoveAt(index);

                return person;
            }

            return null;
        }

        public List<NewTaskRequestModel> AddList(List<NewTaskRequestModel> persons)
        {
            _person.AddRange(persons);

            return persons;
        }
    }
}