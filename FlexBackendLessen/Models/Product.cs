using System.ComponentModel.DataAnnotations;

namespace FlexBackendLessen.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
