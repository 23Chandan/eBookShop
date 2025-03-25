using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using eBookShop.Repositories.DALRepository;

namespace eBookShop.Services.BALServices
{
    public class ProductBalServices : IProductBal
    {
        private readonly IProduct _product;
        public ProductBalServices(IProduct product)
        {
            _product = product;
        }
        public async Task AddProductAsync(ProductModel data)
        {
            await _product.AddProductAsync(data);
        }

        public Task DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProductAsync()
        {
            return await _product.GetProductAsync();
        }

        public Task<ProductModel> GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductModel data)
        {
            throw new NotImplementedException();
        }
    }
}
