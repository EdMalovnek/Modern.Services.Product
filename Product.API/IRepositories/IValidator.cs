namespace Product.API
{
    public interface IValidator
    {
        Task<bool> IsProductValid(ProductViewModel product);
    }
}
