using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.ProductsRepository;

public interface IProductsRepository
{
    public Task<List<FundProject>> GetProducts();
    public Task<List<Product>> GetMostSelling();
    public Task CreateAssetsFolders();
    public Task<List<FundProject>> GetProductsByCategory(string category);
    public Task AddProduct(ProductDTO producttoadd);
    public Task UpdateProduct(ProductDTO producttoupdate);
    public Task RemoveProduct(ProductDTO producttoremove);

}