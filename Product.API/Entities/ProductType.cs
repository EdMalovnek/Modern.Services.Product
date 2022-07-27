using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API
{
    [Table("ProductType")]
    public class ProductType
    {
        [Column("ProductTypeID")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
