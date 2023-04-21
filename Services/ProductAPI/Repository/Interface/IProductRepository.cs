using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.DTOs;

namespace ProductAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateProduct(CreateProductDto productDto);
        Task<ProductDto> UpdateProduct(UpdateProductDto productDto);
        Task<bool> DeleteProduct(int productId);


    }
}