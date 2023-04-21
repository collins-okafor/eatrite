using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductAPI.Repository.Interface;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        protected ResponseDto _response;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                return Ok( new
                {
                    message = "Successful",
                    StatusCode = 200,
                    IsSuccessful = true,
                    data = productDtos,
                });
              

            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest( new
                {
                    message =  _response.ErrorMessages,
                    IsSuccessful = false
                });
            }
        }


        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                return Ok( new
                {
                    message = "Successful",
                    StatusCode = 200,
                    IsSuccessful = true,
                    data = product
                });
            }
            catch (Exception ex)
            {

                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest( new
                {
                    message = _response.ErrorMessages,
                    IsSuccessful = false
                });
            }
        }

        [HttpPost]
        public async Task<object> Post([FromBody] CreateProductDto productDto)
        {
            try
            {
                var product = await _productRepository.CreateProduct(productDto);
                return Ok( new
                {
                    message = "Successful",
                    StatusCode = 200,
                    IsSuccessful = true,
                    data = product
                });

            }
            catch (Exception ex)
            {

                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest( new
                {
                    message = _response.ErrorMessages,
                    IsSuccessful = false
                });
            }
        }

        [HttpPut]
        public async Task<object> Put([FromBody] UpdateProductDto productDto)
        {
            try
            {
                var product = await _productRepository.UpdateProduct(productDto);
                _response.Result = product;
                return Ok( new
                {
                    message = "Successful",
                    StatusCode = 200,
                    IsSuccessful = true,
                    data = product
                });

            }
            catch (Exception ex)
            {

                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest( new
                {
                    message =  _response.ErrorMessages,
                    IsSuccessful = false
                });
            }
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool IsSuccessful = await _productRepository.DeleteProduct(id);
                _response.Result = IsSuccessful;

                return Ok( new
                {
                    message = "Product deleted successfully",
                    StatusCode = 200,
                    IsSuccessful = true,
                });

            }
            catch (Exception ex)
            {

                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest( new
                {
                    message = _response.ErrorMessages,
                    IsSuccessful = false
                });
            }
        }

    }
}