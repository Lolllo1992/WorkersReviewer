using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //Si crea task asincorno per ottenere i prodotti by ID
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}