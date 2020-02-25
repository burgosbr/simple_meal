using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleMeal.Data;
using SimpleMeal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMeal.Controllers
{
    [ApiController]
    [Route("/tables")]
    public class TableController: ControllerBase
    {
        private readonly DataContext _context;

        public TableController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Table>>> Get()
        {
            var tables = await _context.Tables.ToListAsync();
            return tables;
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
