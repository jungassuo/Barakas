using Barakas.Services.ShoppingCartAPI.Models.Dto;

namespace Barakas.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
