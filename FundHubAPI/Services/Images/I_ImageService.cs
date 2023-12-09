namespace FundHubAPI.Services.Images;

public interface I_ImageService
{
    public Task<byte[]> ServeImage(string imagename, Guid productid);
}