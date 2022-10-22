using assignment2.DTOs.Categories;
using System.Linq.Expressions;

namespace assignment2.Services
{
    public interface ICategoryService
    {
        IEnumerable<AddCategoryResponse> GetAll(Expression<Func<AddCategory, bool>>? predicate);
        AddCategoryResponse? Add(AddCategory addModel);
        AddCategoryResponse? Get(Expression<Func<AddCategoryResponse, bool>> predicate, int id);
        bool Delete(int id);
        AddCategoryResponse? Update(int id, AddCategory createModel);
    }
}