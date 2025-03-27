using System.ComponentModel.DataAnnotations;

namespace eBookShop.DTOs
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, ErrorMessage = "Author name can't be more than 100 characters.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [StringLength(50, ErrorMessage = "Category name can't be more than 50 characters.")]
        public string Category { get; set; }
        [StringLength(500, ErrorMessage = "Description length can't be more than 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Language is required.")]
        public List<string> Language { get; set; }
        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative.")]
        public int StockQuantity { get; set; }
        [Required(ErrorMessage = "Page count is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Page count must be greater than zero.")]
        public int PageCount { get; set; }
        public IFormFile ProductImage { get; set; }
        public IFormFile ProductPdf { get; set; }
        public bool IsBestSeller { get; set; } = false;
    }
}
