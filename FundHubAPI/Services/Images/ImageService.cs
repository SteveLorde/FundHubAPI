using FundHubAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services.Images;

class ImageService : I_ImageService {
    
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly DataContext _db;

    public ImageService(IWebHostEnvironment hostingEnvironment, DataContext db)
    {
        _hostingEnvironment = hostingEnvironment;
        _db = db;
    }

    public async Task<byte[]> ServeImage(string imagename, Guid productid)
    {
        try
        {
            var imagePath = Path.Combine(_hostingEnvironment.ContentRootPath,"Storage", "ProductImages", $"{productid}", imagename);
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return imageBytes;
        }
        catch (Exception err)
        {
            throw err;
        }
    }


}