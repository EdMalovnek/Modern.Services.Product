using Microsoft.EntityFrameworkCore;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;
        private IValidator _validator;

        public ProductRepository(ProductDbContext db, IValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<Product> Get(string itemCode)
        {
            var result = await _db.Products.Where(x => x.ItemCode == itemCode).FirstOrDefaultAsync();

            return result;
        }

        public async Task<string> Create(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return "Successfully created Product";
        }

        public async Task<string> Update(Product product)
        {
            var existingProduct = await _db.Products.Where(x => x.ItemCode == product.ItemCode).FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                existingProduct.Id = product.Id;
                existingProduct.ItemCode = product.ItemCode;
                existingProduct.ProductType = product.ProductType;
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.RefItemCode = product.RefItemCode;
                existingProduct.ModificationDate = DateTime.Now.ToLocalTime();

                await _db.SaveChangesAsync();
            }
            else
            {
                return "No matching product found to update";
            }

            return "Update successful";
        }
    }
}
