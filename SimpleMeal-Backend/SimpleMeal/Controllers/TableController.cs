using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Repository;
using SimpleMeal.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMeal.Controllers
{
    [ApiController]
    [Route("api/tables")]
    public class TableController: ControllerBase
    {
        private readonly SimpleMealContext _context;

        public TableController(SimpleMealContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Tables.ToListAsync();
                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha na requisição!");
            }
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> Get(string number)
        {
            try
            {
                var results = await _context.Tables.FirstOrDefaultAsync(x => x.Number== number);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha na requisição!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Table>> Post([FromBody] Table model)
        {
            if(ModelState.IsValid)
            {
                _context.Tables.Add(model);
                await _context.SaveChangesAsync();
                return model;
            } else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
