using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Repository;
using SimpleMeal.Domain;
using System;
using System.Threading.Tasks;

namespace SimpleMeal.Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrderController: ControllerBase
    {
        private readonly SimpleMealContext _context;

        public OrderController(SimpleMealContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Orders.ToListAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order model)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha na requisição!");
            }
        }
    }
}
