using assignment2.Models;
using assignment2.Filter;

namespace assignment2.Services
{
    public interface ITaskServices
    {
        List<NewTaskRequestModel> GetAll();

        NewTaskRequestModel? GetOne(Guid index);

        NewTaskRequestModel Create(NewTaskRequestModel model);

        NewTaskRequestModel? Update(Guid index, NewTaskRequestModel model);

        NewTaskRequestModel? Delete(Guid index);

        IEnumerable<NewTaskRequestModel> GetPagnition(OwnerParameters ownerParameters);

        List<NewTaskRequestModel> FilterList(string firstName, string lastName, string gender, string birthPlace);
    }
}