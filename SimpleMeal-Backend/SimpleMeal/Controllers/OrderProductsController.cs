using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMeal.Repository;

namespace SimpleMeal.API.Controllers
{
    [Route("api/orderproducts")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly ISimpleMealRepository _repo;

        public OrderProductsController(ISimpleMealRepository repo)
        {
            _repo = repo;
        }

        // GET: api/OrderProducts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _repo.GetAllOrderProductsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição");
            }

        }

        // GET: api/OrderProducts/5
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            try
            {
                var results = await _repo.GetAllOrderProductsAsyncByOrder(orderId);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }

        // POST: api/OrderProducts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OrderProducts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
