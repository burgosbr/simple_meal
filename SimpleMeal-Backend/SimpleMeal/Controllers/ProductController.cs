using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Repository;
using SimpleMeal.Domain;

namespace SimpleMeal.Controllers
{
  [ApiController]
  [Route("/products")]
  public class ProductController : ControllerBase
  {
    public readonly SimpleMealContext _context;

    public ProductController(SimpleMealContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
      var products = await _context.Products.ToListAsync();
      return products;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product model)
    {
      if (ModelState.IsValid)
      {
        _context.Products.Add(model);
        await _context.SaveChangesAsync();
        return model;
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}