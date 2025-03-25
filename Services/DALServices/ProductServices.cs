using eBookShop.Data;
using eBookShop.Model;
using eBookShop.Repositories.DALRepository;
using Microsoft.EntityFrameworkCore;

namespace eBookShop.Services.DALServices
{
    public class ProductServices : IProduct
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProductAsync(ProductModel data)
        {
           await  _dbContext.AddAsync(data);
           await _dbContext.SaveChangesAsync();
        }

        public Task DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProductAsync()
        {
            return await _dbContext.Product.ToArrayAsync();
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
