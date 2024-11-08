using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;

namespace E_Ticaret_WebApplication.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(a => new ProductDto { Id = a.Id, Name = a.Name, Price= a.Price, Description = a.Description , Stock = a.Stock, ImageUrl = a.ImageUrl, CategoryId= a.CategoryId });
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product != null ? new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description, Stock = product.Stock, ImageUrl = product.ImageUrl, CategoryId = product.CategoryId } : null;
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, Price=productDto.Price, Description = productDto.Description, Stock = productDto.Stock, ImageUrl = productDto.ImageUrl, CategoryId = productDto.CategoryId };
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = new Product { Id=productDto.Id, Name = productDto.Name, Price = productDto.Price, Description = productDto.Description, Stock = productDto.Stock, ImageUrl = productDto.ImageUrl, CategoryId = productDto.CategoryId };
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
