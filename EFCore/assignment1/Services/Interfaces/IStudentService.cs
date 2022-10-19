using assignment1.DTOs;
using System.Linq.Expressions;

namespace assignment1.Services
{
    public interface IStudentService
    {
        IEnumerable<AddStudentResponse> GetAll(Expression<Func<AddStudentRequest, bool>> predicate);

        AddStudentResponse Create(AddStudentRequest createModel);

        AddStudentResponse? Get(Expression<Func<AddStudentResponse, bool>> predicate, int id);

        AddStudentResponse Update(int id, AddStudentRequest createModel);

        bool Delete(int id);
    }
}