using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe.Data;
using Recipe.Model;

namespace Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooksController : ControllerBase
    {
        private readonly RecipeContext _context;

        public CooksController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/Cooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cook>>> Getcooks()
        {
            return await _context.cooks.ToListAsync();
        }

        // GET: api/Cooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cook>> GetCook(int id)
        {
            var cook = await _context.cooks.FindAsync(id);

            if (cook == null)
            {
                return NotFound();
            }

            return cook;
        }

        // PUT: api/Cooks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCook(int id, Cook cook)
        {
            if (id != cook.Id)
            {
                return BadRequest();
            }

            _context.Entry(cook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cooks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cook>> PostCook(Cook cook)
        {
            _context.cooks.Add(cook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCook", new { id = cook.Id }, cook);
        }

        // DELETE: api/Cooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cook>> DeleteCook(int id)
        {
            var cook = await _context.cooks.FindAsync(id);
            if (cook == null)
            {
                return NotFound();
            }

            _context.cooks.Remove(cook);
            await _context.SaveChangesAsync();

            return cook;
        }

        private bool CookExists(int id)
        {
            return _context.cooks.Any(e => e.Id == id);
        }
    }
}
