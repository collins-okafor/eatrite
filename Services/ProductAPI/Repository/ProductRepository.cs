using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.DTOs;
using ProductAPI.Models;
using ProductAPI.Repository.Interface;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<CreateProductDto, Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(UpdateProductDto productDto)
        {
            var product = await _context.Products.FindAsync(productDto.ProductId);
            
            if(product == null)
            {
               throw new Exception($"Product with ID {productDto.ProductId} not found.");
            }

            var updateproduct = _mapper.Map<UpdateProductDto, Product>(productDto, product);
    
            _context.Products.Update(updateproduct);
            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(updateproduct);
        }


        public async Task<bool> DeleteProduct(int productId) 
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if(product == null)
                {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _context.Products.Where(u => u.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}