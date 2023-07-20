using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomersekletekController : ControllerBase
    {
        private readonly HomersekletekDbContext _context;
        public HomersekletekController(HomersekletekDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Homersekletek>> GetHomersekletek()
        {
            return await _context.Homersekletek.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Homersekletek), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHomersekletek(int id)
        {
            var homersekletek = await _context.Homersekletek.FindAsync(id);

            if (homersekletek == null)
            {
                return NotFound();
            }

            return Ok(homersekletek);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostHomersekletek(Homersekletek homersekletek)
        {
            await _context.Homersekletek.AddAsync(homersekletek);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHomersekletek), new { id = homersekletek.HofokId }, homersekletek);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutHomersekletek(int id, Homersekletek homersekletek)
        {
            if (id != homersekletek.HofokId)
            {
                return BadRequest();
            }

            _context.Entry(homersekletek).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHomersekletek(int id)
        {
            var homersekletek = await _context.Homersekletek.FindAsync(id);

            if (homersekletek == null)
            {
                return NotFound();
            }

            _context.Homersekletek.Remove(homersekletek);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
