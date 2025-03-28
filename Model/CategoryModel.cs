using System.ComponentModel.DataAnnotations;

namespace eBookShop.Model
{
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
