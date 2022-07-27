using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API
{
    [Table("Product")]
    public class Product : ProductViewModel
    {
        [Column("ProductID")]
        public Guid Id { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column("ProductTypeID")]
        private int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public string RefItemCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}