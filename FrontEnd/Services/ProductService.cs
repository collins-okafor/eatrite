using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.ConstantHolder;
using FrontEnd.DTOs;
using FrontEnd.Models;
using FrontEnd.Services.IServices;

namespace FrontEnd.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(CreateProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST, 
                Data = productDto,
                Url = SD.ProductAPIBase + "api/products",
                AccessToken = ""
                
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST, 
                Url = SD.ProductAPIBase + "api/products"+id,
                AccessToken = ""
                
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET, 
                Url = SD.ProductAPIBase + "api/products",
                AccessToken = ""
                
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET, 
                Url = SD.ProductAPIBase + "api/products"+id,
                AccessToken = ""
                
            });
        }

        public async Task<T> UpateProductAsync<T>(UpdateProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT, 
                Data = productDto,
                Url = SD.ProductAPIBase + "api/products",
                AccessToken = ""
                
            });
        }
    }
}