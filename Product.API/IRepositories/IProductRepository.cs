using Microsoft.AspNetCore.Mvc;

namespace Product.API
{
    public interface IProductRepository
    {
        Task<Product> Get(string itemCode);
        Task<string> Create(Product product);
        Task<string> Update(Product product);
    }
}
