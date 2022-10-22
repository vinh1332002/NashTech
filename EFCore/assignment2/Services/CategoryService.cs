using assignment2.DTOs.Categories;
using System.Linq.Expressions;
using assignment2.Repositories;
using assignment2.Models;

namespace assignment2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public AddCategoryResponse? Add(AddCategory addModel)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var addCategory = new Category
                    {
                        CategoryName = addModel.CategoryName
                    };

                    var newCategory = _categoryRepo.Create(addCategory);
                    _categoryRepo.SaveChanges();

                    transaction.Commit();

                    return new AddCategoryResponse
                    {
                        Id = newCategory.Id,
                        CategoryName = newCategory.CategoryName,
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public IEnumerable<AddCategoryResponse> GetAll(Expression<Func<AddCategory, bool>>? predicate)
        {
            var viewModels = _categoryRepo.GetAll(x => true)
                .Select(category => new AddCategoryResponse
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });

            return viewModels;
        }

        public AddCategoryResponse? Get(Expression<Func<AddCategoryResponse, bool>> predicate, int id)
        {
            var category = _categoryRepo.Get(g => g.Id == id);

            if (category == null) { return null; }

            var getModels = new AddCategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            return getModels;
        }

        public bool Delete(int id)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(x => x.Id == id);

                    if (category != null)
                    {
                        _categoryRepo.Delete(category);
                        _categoryRepo.SaveChanges();
                    }
                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.RollBack();
                    return true;
                }
            }
        }

        public AddCategoryResponse? Update(int id, AddCategory updateModel)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(x => x.Id == id);

                    if (category == null) { return null; }

                    category.CategoryName = updateModel.CategoryName;

                    category = _categoryRepo.Update(category);

                    if (category == null) return null;

                    var viewModel = new Category
                    {
                        CategoryName = category.CategoryName,
                    };

                    _categoryRepo.SaveChanges();

                    transaction.Commit();

                    return new AddCategoryResponse
                    {
                        Id = category.Id,
                        CategoryName = updateModel.CategoryName,
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}