using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Data;
using SimpleMeal.Models;

namespace SimpleMeal.Controllers
{
  [ApiController]
  [Route("/products")]
  public class ProductController : ControllerBase
  {
    public readonly DataContext _context;

    public ProductController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> Get()
    {
      var products = await _context.Products.ToListAsync();
      return products;
    }

    [HttpPost]
    [Route("")]
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