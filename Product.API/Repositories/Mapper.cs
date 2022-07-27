using Microsoft.EntityFrameworkCore;

namespace Product.API
{
    public class Mapper : IMapper
    {
        private readonly ProductDbContext _db;

        public Mapper(ProductDbContext db)
        {
            _db = db;
        }
        public async Task<Product> Map(ProductViewModel product)
        {
            var productTypes = await _db.ProductTypes.ToListAsync();

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                ItemCode = product.ItemCode,
                Description = product.Description,
                Type = product.Type,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                RefItemCode = product.RefItemCode,
                ProductType = productTypes.Where(x => x.Id == product.ProductType).First()
            };
        }
    }
}
