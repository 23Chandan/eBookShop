using eBookShop.DTOs;
using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using eBookShop.Repositories.DALRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eBookShop.Services.BALServices
{
    public class ProductBalServices : IProductBal, IProcessOnImage
    {
        private readonly IProduct _product;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductBalServices(IProduct product, IHttpContextAccessor httpContextAccessor)
        {
            _product = product;
            _httpContextAccessor = httpContextAccessor;
        }
        private string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
            {
                return "http://localhost:5000";
            }

            return $"{request.Scheme}://{request.Host.Value}";
        }
        public async Task AddProductAsync(ProductDto data)
        {
            
            var imagePath = await saveImageAsync(data.ProductImage);
            var pdfPath = await savePdfAsync(data.ProductPdf);
            var d = new ProductModel()
            {
                Title = data.Title,
                Author = data.Author,
                Price = data.Price,
                Category = data.Category,
                Description = data.Description,
                Language = string.Join(",", data.Language),
                StockQuantity = data.StockQuantity,
                PageCount = data.PageCount,
                ImageUrl = imagePath, 
                PdfUrl = pdfPath, 
                IsBestSeller = data.IsBestSeller
            };
            await _product.AddProductAsync(d);
        }

        public async Task DeleteProduct(int Id)
        {
            await _product.DeleteProduct(Id);
        }

        public async Task<IEnumerable<ProductModel>> GetProductAsync()
        {
            return await _product.GetProductAsync();
        }

        public async Task<ProductModel> GetProductById(int Id)
        {
            return await _product.GetProductById(Id);
        }       

        public async Task UpdateProductAsync(ProductDto data)
        {
            var imagePath = await saveImageAsync(data.ProductImage);
            var pdfPath = await savePdfAsync(data.ProductImage);
            var d = new ProductModel()
            {
                Id=data.Id,
                Title = data.Title,
                Author = data.Author,
                Price = data.Price,
                Category = data.Category,
                Description = data.Description,
                Language = string.Join(",", data.Language),
                StockQuantity = data.StockQuantity,
                PageCount = data.PageCount,
                ImageUrl = imagePath,
                PdfUrl = pdfPath,
                IsBestSeller = data.IsBestSeller
            };
            await  _product.UpdateProductAsync(d);
        }
        public async Task<string> saveImageAsync(IFormFile i)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductImage");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(i.FileName);
            string filePath = Path.Combine(uploadsFolder, imageName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await i.CopyToAsync(stream);
            }
            string baseUrl = GetBaseUrl();
            return $"{baseUrl}/ProductImage/{imageName}";
        }


        public async Task<string> savePdfAsync(IFormFile i)
        {
            string uploadPdfFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","ProductPdf");
            if (!Directory.Exists(uploadPdfFile))
            {
                Directory.CreateDirectory(uploadPdfFile);
            }
            string pdfName = Guid.NewGuid().ToString() + Path.GetExtension(i.FileName);
            string pdfFilePath = Path.Combine(uploadPdfFile, pdfName);
            using(var stream = new FileStream(pdfFilePath, FileMode.Create))
            {
                await i.CopyToAsync(stream);
            }
            string baseUrl = GetBaseUrl();
            return $"{baseUrl}/ProductPdf/{pdfName}";
        }

    }
}
