using eBookShop.DTOs;
using eBookShop.Model;

namespace eBookShop.Repositories.BALRepository
{
    public interface IProductBal
    {
        Task<IEnumerable<ProductModel>> GetProductAsync();
        Task<ProductModel> GetProductById(int Id);
        Task UpdateProductAsync(ProductDto data);
        Task AddProductAsync(ProductDto data);
        Task DeleteProduct(int Id);
    }
    public interface IProcessOnImage
    {
        Task<string> saveImageAsync(IFormFile productImage);
        Task<string> savePdfAsync(IFormFile productPdf );
    }
}
