using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

/*
[Authorize]
*/
[ApiController]
[Route("Shopping")]
public class ShoppingController : Controller
{
    [HttpGet("AddToCartCheck/${id}")]
    public IActionResult AddToCartCheck(int productid)
    {
        return Ok();
    }
}