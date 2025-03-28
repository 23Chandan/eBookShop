using eBookShop.Data;
using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using eBookShop.Repositories.DALRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookShop.Services.DALServices
{
    public class ProductServices : IProduct, ICategory
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(ProductModel data)
        {
            await _dbContext.Product.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dbContext.Product.FindAsync(id);
            if (product != null)
            {
                _dbContext.Product.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }        

        public async Task<IEnumerable<ProductModel>> GetProductAsync()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _dbContext.Product.FindAsync(id);
        }

        public async Task UpdateProductAsync(ProductModel data)
        {
            var existingProduct = await _dbContext.Product.FindAsync(data.Id);
            if (existingProduct != null)
            {
                existingProduct.Title = data.Title;
                existingProduct.Description = data.Description;
                existingProduct.Price = data.Price;
                existingProduct.ImageUrl = data.ImageUrl;
                existingProduct.PdfUrl = data.PdfUrl;
                existingProduct.Author = data.Author;
                existingProduct.Language = data.Language;
                existingProduct.StockQuantity = data.StockQuantity;
                existingProduct.PageCount = data.PageCount;
                existingProduct.IsBestSeller = data.IsBestSeller;
                existingProduct.UpdatedOn = DateTime.UtcNow;
                _dbContext.Product.Update(existingProduct);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<CategoryModel>> GetCategoryAsync()
        {
            return await _dbContext.Category.ToArrayAsync();
        }
    }
}
