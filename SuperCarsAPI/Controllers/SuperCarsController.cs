using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperCarsAPI.Models;

namespace SuperCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperCarsController : ControllerBase
    {
        private readonly SuperCarsAPIContext _context;

        public SuperCarsController(SuperCarsAPIContext context)
        {
            _context = context;
        }

        // GET: api/SuperCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperCar>>> GetSuperCar()
        {
            return await _context.SuperCar.ToListAsync();
        }

        // GET: api/SuperCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperCar>> GetSuperCar(int id)
        {
            var superCar = await _context.SuperCar.FindAsync(id);

            if (superCar == null)
            {
                return NotFound();
            }

            return superCar;
        }

        // PUT: api/SuperCars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperCar(int id, SuperCar superCar)
        {
            if (id != superCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(superCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperCarExists(id))
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

        // POST: api/SuperCars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuperCar>> PostSuperCar(SuperCar superCar)
        {
            _context.SuperCar.Add(superCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperCar", new { id = superCar.Id }, superCar);
        }

        // DELETE: api/SuperCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperCar(int id)
        {
            var superCar = await _context.SuperCar.FindAsync(id);
            if (superCar == null)
            {
                return NotFound();
            }

            _context.SuperCar.Remove(superCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperCarExists(int id)
        {
            return _context.SuperCar.Any(e => e.Id == id);
        }
    }
}
