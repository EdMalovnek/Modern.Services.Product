using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IValidator _validator;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository, IValidator validator, IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }
        /// <summary>
        /// Returns a single product by its itemCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{itemCode}")]
        public async Task<ResponseJSON> Get(string itemCode)
        {
            var result = await _productRepository.Get(itemCode);

            return new ResponseJSON
            {
                Response = result ?? new Product(),
                Message = result == null ? "No Product with that itemCode exists" : "Successfuly retrieved product"
            }; ;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ResponseJSON> Create(ProductViewModel product)
        {
            var result = "Error";
            var mappedProduct = await _mapper.Map(product);

            if (await _validator.IsProductValid(product) && ModelState.IsValid)
            {
                result = await _productRepository.Create(mappedProduct);
            }

            return new ResponseJSON
            {
                Message = result
            };
        }

        [HttpPost("Update")]
        public async Task<ResponseJSON> Update(ProductViewModel product)
        {
            var result = "Error";

            var mappedProduct = await _mapper.Map(product);

            if (await _validator.IsProductValid(product) && ModelState.IsValid)
            {
                result = await _productRepository.Update(mappedProduct);
            }

            return new ResponseJSON
            {
                Message = result
            };
        }
    }
}