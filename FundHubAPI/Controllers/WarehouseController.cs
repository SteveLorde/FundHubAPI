using API.Services.Images;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.ProductsRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

/*
[Authorize]
*/
[ApiController]
[Route("Warehouse")]
public class WarehouseController : Controller
{
    private readonly IProductsRepository _warehouse;
    private readonly I_ImageService _imageservice;

    public WarehouseController(IProductsRepository warehouse, I_ImageService imageService)
    {
        _warehouse = warehouse;
        _imageservice = imageService;
    }

    [HttpGet("GetAllProducts")]
    public async Task<List<Product>> GetAllProducts()
    {
        return await _warehouse.GetProducts();
    }
    
    [HttpGet("GetCategorizedProducts/${category}")]
    public async Task<List<Product>> GetCategorizedProducts(string category)
    {
        return await _warehouse.GetProductsByCategory(category);
    }

    [HttpGet("MostSelling")]
    public async Task<List<Product>> ReturnMostSelling()
    {
        return await _warehouse.GetMostSelling();
    }

    [HttpGet("GetImage/${productid}/${imagename}")]
    public async Task<FileContentResult> GetImage(Guid productid,string imagename)
    {
        var image = await _imageservice.ServeImage(imagename, productid);
        return File(image, "image/jpeg");
    }
    
}