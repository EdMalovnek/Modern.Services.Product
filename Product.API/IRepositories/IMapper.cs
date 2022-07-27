namespace Product.API
{
    public interface IMapper
    {
        Task<Product> Map(ProductViewModel product);
    }
}
