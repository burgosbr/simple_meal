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
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ISimpleMealRepository _repo;

        public OrderController(ISimpleMealRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _repo.GetAllOrdersAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            try
            {
                var results = await _repo.GetOrderAsyncById(orderId);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requesição!");
            }
        }
        [HttpGet("{clientName}")]
        public async Task<IActionResult> GetByClientName(string clientName)
        {
            try
            {
                var results = await _repo.GetAllOrdersAsyncByClientName(clientName);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }
        [HttpGet("{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            try
            {
                var results = await _repo.GetAllOrdersAsyncByStatus(status);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/order/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }

            return BadRequest();
        }
        [HttpPut("{orderId}")]
        public async Task<IActionResult> Put(int orderId, [FromBody]Order model)
        {
            try
            {
                var evento = await _repo.GetOrderAsyncById(orderId);
                if (evento == null) return NotFound("Pedido não encontrado!");

                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/order/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição!");
            }
            return BadRequest();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                var order = await _repo.GetOrderAsyncById(orderId);
                if (order == null) return NotFound("Pedido não encontrado!");

                _repo.Delete(order);
                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Pedido apagado com sucesos!");
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
