using eBookShop.Model;

namespace eBookShop.Repositories.BALRepository
{
    public interface IProductBal
    {
        Task<IEnumerable<ProductModel>> GetProductAsync();
        Task<ProductModel> GetProductById(int Id);
        Task UpdateProductAsync(ProductModel data);
        Task AddProductAsync(ProductModel data);
        Task DeleteProduct(int Id);
    }
}
