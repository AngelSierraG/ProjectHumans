using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.DateTimeHumanizeStrategy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHumans.Models;

namespace ProjectHumans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly DbhumansContext _context;

        public HumanController(DbhumansContext context)
        {
            _context = context;
        }

        // GET: api/Human
        [HttpGet("mock")]
        public List<Human> GetHumansMock()
        {
            List<Human> oHuman = new List<Human>();
           
            for (short i = 1; i <= 50;i++) {

                oHuman.Add(new Human
                {
                    Id = i,
                    Name = "Nombre #"+i,
                    Sex = "H",
                    Age = "1"+i,
                    Height = "1."+i,
                    Weight = "1"+i,

                });
            }

           

            return oHuman;
        }

        // GET: api/Human
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Human>>> GetHumans()
        {
          if (_context.Humans == null)
          {
              return NotFound();
          }
            return await _context.Humans.ToListAsync();
        }


        // GET: api/Human/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Human>> GetHuman(short id)
        {
          if (_context.Humans == null)
          {
              return NotFound();
          }
            var human = await _context.Humans.FindAsync(id);

            if (human == null)
            {
                return NotFound();
            }

            return human;
        }

        // PUT: api/Human/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuman(short id, Human human)
        {
            if (id != human.Id)
            {
                return BadRequest();
            }

            _context.Entry(human).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanExists(id))
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

        // POST: api/Human
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Human>> PostHuman(Human human)
        {
          if (_context.Humans == null)
          {
              return Problem("Entity set 'DbhumansContext.Humans'  is null.");
          }
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHuman", new { id = human.Id }, human);
        }

        // DELETE: api/Human/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuman(short id)
        {
            if (_context.Humans == null)
            {
                return NotFound();
            }
            var human = await _context.Humans.FindAsync(id);
            if (human == null)
            {
                return NotFound();
            }

            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HumanExists(short id)
        {
            return (_context.Humans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
