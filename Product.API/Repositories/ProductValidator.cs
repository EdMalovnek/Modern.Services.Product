using Microsoft.EntityFrameworkCore;

namespace Product.API
{
    public class ProductValidator : IValidator
    {
        private readonly ProductDbContext _db;

        public ProductValidator(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<bool> IsProductValid(ProductViewModel product)
        {
            var existingProducts = await _db.Products.ToListAsync();
            var productTypes = await _db.ProductTypes.ToListAsync();

            var productTypeId = productTypes.Where(x => x.Id == product.ProductType).First().Id;

            if(existingProducts.Any(x=> x.ItemCode == product.ItemCode))
                return false;

            if (productTypeId == (int)ProductTypeEnum.Tester)
            {
                if(product.Price == null)
                    return false;
                if(!product.ItemCode.StartsWith("T-"))
                    return false;
            }
            else if (productTypeId == (int)ProductTypeEnum.Sample)
            {
                if(!existingProducts.Any(x => x.RefItemCode == product.RefItemCode))
                    return false;
                if (!product.ItemCode.StartsWith("S-"))
                    return false;
            }
            else if(productTypeId == (int)ProductTypeEnum.Regular)
            {
                if (!product.ItemCode.StartsWith("R-"))
                    return false;
            }

            return true;
        }
    }
}
