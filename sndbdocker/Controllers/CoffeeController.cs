using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sndbdocker.Data;
using sndbdocker.Models;

namespace sndbdocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly HomersekletekDbContext _context;

        public CoffeeController(HomersekletekDbContext context) => _context = context;

        // GET: api/Coffee
        [HttpGet]

        public async Task<IEnumerable<Coffee>> GetCoffee()
        {
            return await _context.Coffee.ToListAsync();
        }
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var coffee = _context.Coffee.ToList();
        //        if (coffee.Count == 0)
        //        {
        //            return NotFound("Coffee not available");
        //        }
        //        return Ok(coffee);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}



        // GET api/Coffee/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Coffee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCoffee(int id)
        {
            var coffee = await _context.Coffee.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return Ok(coffee);
        }
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        var coffee = _context.Coffee.Find(id);
        //        if (coffee == null)
        //        {
        //            return NotFound($"Coffee details not found with id {id}");
        //        }
        //        return Ok(coffee);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        // POST api/Coffee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostCoffee(Coffee coffee)
        {
            await _context.Coffee.AddAsync(coffee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoffee), new { id = coffee.Id }, coffee);
        }
        //public IActionResult Post(Coffee model)
        //{
        //    try
        //    {
        //        _context.Add(model);
        //        _context.SaveChanges();
        //        return Ok("Coffee created.");
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        // PUT api/Coffee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCoffee(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //public IActionResult Put(Coffee model)
        //{
        //    if (model == null || model.Id == 0)
        //    {
        //        if (model == null)
        //        {
        //            return BadRequest("Model data is invalid.");
        //        }
        //        else if (model.Id == 0)
        //        {
        //            return BadRequest($"Coffee Id {model.Id} is invalid.");
        //        }
        //    }
        //    try
        //    {
        //        var coffee = _context.Coffee.Find(model.Id);
        //        if (coffee == null)
        //        {
        //            return NotFound($"Product not found with id {model.Id}");
        //        }
        //        coffee.Name = model.Name;
        //        coffee.Roaster = model.Roaster;
        //        coffee.Image = model.Image;
        //        _context.SaveChanges();
        //        return Ok("Product details updated.");
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCoffee(int id)
        {
            var coffee = await _context.Coffee.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }

            _context.Coffee.Remove(coffee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var coffee = _context.Coffee.Find(id);
        //        if (coffee == null)
        //        {
        //            return NotFound($"Coffee details not found with id {id}");
        //        }
        //        _context.Remove(coffee);
        //        _context.SaveChanges();
        //        return Ok("Coffee deleted.");
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
       
    }
}
