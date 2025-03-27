using System.ComponentModel.DataAnnotations;

namespace eBookShop.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }  

        [StringLength(500)]
        public string Description { get; set; }


        [Required]
        public string Language { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PageCount { get; set; }

        public string? ImageUrl { get; set; }  

        public string? PdfUrl { get; set; }  

        public bool IsBestSeller { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } 

    }
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name can't be more than 100 characters.")]
        public string Name { get; set; } 

        [StringLength(500, ErrorMessage = "Description can't be more than 500 characters.")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true; 

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ProductModel>? Products { get; set; }
    }
}
