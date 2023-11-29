using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.ProductsRepository;

class ProductsRepository : IProductsRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    public List<Product> primarymostselling = new List<Product>();
    private readonly IWebHostEnvironment _hostingenv;

    public ProductsRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostingenv = hostingEnvironment;
    }
    
    public async Task<List<FundProject>> GetProducts()
    {
        return await _db.FundProjects.ToListAsync();
    }

    public async Task<List<FundProject>> GetProductsByCategory(string category)
    {
        return await _db.FundProjects.Where(x => x.category == category).ToListAsync();
    }
    
    public async Task CreateAssetsFolders()
    {
        try
        {
            List<FundProject> allproducts = await _db.FundProjects.ToListAsync();
            foreach (FundProject product in allproducts)
            {
                var productfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "Products",
                    $"{product.Id}", "Images");
                Directory.CreateDirectory(productfoldertocreate); 
            }
            Console.WriteLine("Created Products assets folders successfully");
        }
        catch (Exception err)
        {
            throw err;
        }
    }


    public async Task AddProduct(ProductDTO producttoadd)
    {
        Product newproduct = new Product { name = producttoadd.name , description = producttoadd.description, descriptionbullets = producttoadd.descriptionbullets, category = producttoadd.category, price = producttoadd.price, addedon = new DateOnly(2024,1,1), discount = null };
        await _db.FundProjects.AddAsync(newproduct);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProduct(ProductDTO producttoupdate)
    {
        FundProject selectedproduct = await _db.FundProjects.FirstAsync(x => x.Id == producttoupdate.id);
        _mapper.Map(producttoupdate, selectedproduct);
        
        /*
        void functionlol()
        {
            selectedproduct.name = producttoupdate.name;
            selectedproduct.description = producttoupdate.description;
            selectedproduct.category = producttoupdate.category;
            selectedproduct.barcode = producttoupdate.barcode;
            selectedproduct.descriptionbullets = producttoupdate.descriptionbullets;
            selectedproduct.discount = producttoupdate.discount;
            selectedproduct.
        }
        */
        
        await _db.SaveChangesAsync();
    }

    public async Task RemoveProduct(ProductDTO producttoremove)
    {
        FundProject removeproduct = await _db.FundProjects.FirstAsync(x => x.Id == producttoremove.id);
        _db.FundProjects.Remove(removeproduct);
        await _db.SaveChangesAsync();
    }
}   