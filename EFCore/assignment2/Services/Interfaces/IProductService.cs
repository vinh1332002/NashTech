using assignment2.Models;
using assignment2.DTOs.Products;
using System.Linq.Expressions;

namespace assignment2.Services
{
    public interface IProductService
    {
        AddProductResponse? Add(AddProduct addModel);
        IEnumerable<AddProductResponse> GetAll(Expression<Func<AddProduct, bool>>? predicate);
        AddProductResponse? Get(Expression<Func<AddProductResponse, bool>> predicate, int id);
        bool Delete(int id);
        AddProductResponse? Update(int id, AddProduct createModel);
    }
}