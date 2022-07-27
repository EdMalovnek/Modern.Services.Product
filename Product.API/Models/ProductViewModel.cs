using System;
using System.ComponentModel.DataAnnotations;

namespace Product.API
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string ItemCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [MaxLength(1000)]
        public string ImageUrl { get; set; }

        [RegularExpression(@"\d{1,20}(\.\d{1,2})?", ErrorMessage = "Invalid Price. Please use the format of XXXX.XX.")]
        public decimal? Price { get; set; }
        [MaxLength(12)]
        public string RefItemCode { get; set; }

        [Required]
        public int ProductType { get; set; }
    }
}
