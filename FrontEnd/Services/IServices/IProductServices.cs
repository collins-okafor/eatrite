using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.DTOs;

namespace FrontEnd.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(CreateProductDto productDto);
        Task<T> UpateProductAsync<T>(UpdateProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
} 