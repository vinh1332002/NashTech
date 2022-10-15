using assignment1.Models.RequestModels;

namespace assignment1.Services
{
    public interface ITaskServices
    {
        List<NewTaskRequestModel> GetAll();

        NewTaskRequestModel? GetOne(int index);

        NewTaskRequestModel Create(NewTaskRequestModel model);

        NewTaskRequestModel? Update(int index, NewTaskRequestModel model);

        NewTaskRequestModel? Delete(int index);

        List<NewTaskRequestModel> AddList(List<NewTaskRequestModel> persons);

        public void DeleteMulti(List<Guid> indexes);
    }
}