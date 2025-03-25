using eBookShop.Model;

namespace eBookShop.Repositories.DALRepository
{
    public interface IProduct
    {
        Task<IEnumerable<ProductModel>> GetProductAsync();
        Task<ProductModel> GetProductById(int Id);
        Task UpdateProductAsync(ProductModel data);
        Task AddProductAsync(ProductModel data);
        Task DeleteProduct(int Id);
    }
}
