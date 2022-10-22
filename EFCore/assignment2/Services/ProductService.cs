using assignment2.Repositories;
using assignment2.Models;
using assignment2.DTOs.Products;
using System.Linq.Expressions;

namespace assignment2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        private readonly ICategoryRepository _categoryRepo;
        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }
        public AddProductResponse? Add(AddProduct addModel)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(s => s.Id == addModel.CategoryId);

                    if (category != null)
                    {
                        var addProduct = new Product
                        {
                            ProductName = addModel.ProductName,
                            CategoryId = category.Id
                        };

                        var newProduct = _productRepo.Create(addProduct);
                        _productRepo.SaveChanges();

                        transaction.Commit();

                        return new AddProductResponse
                        {
                            ProductId = newProduct.Id,
                            ProductName = newProduct.ProductName,
                            Manufacture = newProduct.Manufacture,
                            CategoryId = newProduct.CategoryId
                        };
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public IEnumerable<AddProductResponse> GetAll(Expression<Func<AddProduct, bool>>? predicate)
        {
            var viewModels = _productRepo.GetAll(x => true)
                .Select(category => new AddProductResponse
                {
                    ProductId = category.Id,
                    ProductName = category.ProductName,
                    Manufacture = category.Manufacture,
                    CategoryId = category.CategoryId
                });

            return viewModels;
        }

        public AddProductResponse? Get(Expression<Func<AddProductResponse, bool>> predicate, int id)
        {
            var product = _productRepo.Get(g => g.Id == id);

            if (product == null) { return null; }

            var getModels = new AddProductResponse
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Manufacture = product.Manufacture,
                CategoryId = product.CategoryId
            };

            return getModels;
        }

        public bool Delete(int id)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var product = _productRepo.Get(x => x.Id == id);

                    if (product != null)
                    {
                        _productRepo.Delete(product);
                        _productRepo.SaveChanges();
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

        public AddProductResponse? Update(int id, AddProduct updateModel)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(s => s.Id == updateModel.CategoryId);

                    var product = _productRepo.Get(x => x.Id == id);

                    if (product == null) return null;

                    product.ProductName = updateModel.ProductName;
                    product.CategoryId = category.Id;

                    product = _productRepo.Update(product);

                    if (product == null) return null;

                    var viewModel = new Product
                    {
                        ProductName = product.ProductName,
                        CategoryId = product.Id,
                    };

                    _productRepo.SaveChanges();

                    transaction.Commit();

                    return new AddProductResponse
                    {
                        ProductId = product.Id,
                        ProductName = updateModel.ProductName,
                        CategoryId = updateModel.CategoryId
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