using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

public class ProductController : Controller
{
    //field
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo)
    {
        _repo = repo;
    }

    
    // GET
    public IActionResult Index()
    {
        var products = _repo.GetAllProducts();
        
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {

        var product = _repo.GetProduct(id);
        return View(product);
    }
}