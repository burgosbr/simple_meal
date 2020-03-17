using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Repository;
using SimpleMeal.Domain;
using System;
using Microsoft.AspNetCore.Http;

namespace SimpleMeal.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        public readonly ISimpleMealRepository _repo;

        public ProductController(ISimpleMealRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _repo.GetAllProductsAsync();
                return Ok(results);
            } catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/products/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }

            return BadRequest();
        }
    }
}