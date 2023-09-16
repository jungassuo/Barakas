using Barakas.Web.Models;
using Barakas.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Barakas.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService) { 
            _ProductService = ProductService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto?> list = new();

            ResponseDto? response = await _ProductService.GetAllProductsAssync();

            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
        public async Task<IActionResult> ProductCreate() 
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto ProductDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _ProductService.CreateProductsAsync(ProductDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(ProductDto);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            ResponseDto? response = await _ProductService.GetProductByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
               

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto Product)
        {
            ResponseDto? response = await _ProductService.DeleteProductsAsync(Product.ProductId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else {
                TempData["error"] = response?.Message;
            }

            return View(Product);
        }

		public async Task<IActionResult> ProductEdit(int id)
		{
			ResponseDto? response = await _ProductService.GetProductByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));


				return View(model);
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductEdit(ProductDto Product)
		{
			ResponseDto? response = await _ProductService.UpdateProductsAsync(Product);

			if (response != null && response.IsSuccess)
			{
				ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
				TempData["success"] = "Product updated successfully";
				return RedirectToAction(nameof(ProductIndex));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(Product);
		}

	}
}
