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
        private readonly CoffeesDbContext _context;

        public CoffeeController(CoffeesDbContext context) => _context = context;

        // GET: api/Coffee
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var coffee = _context.Coffees.ToList();
                if (coffee.Count == 0)
                {
                    return NotFound("Coffee not available");
                }
                return Ok(coffee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        // GET api/Coffee/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var coffee = _context.Coffees.Find(id);
                if (coffee == null)
                {
                    return NotFound($"Coffee details not found with id {id}");
                }
                return Ok(coffee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/Coffee
        [HttpPost]
        public IActionResult Post(Coffee model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Coffee created.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/Coffee/5
        [HttpPut("{id}")]
        public IActionResult Put(Coffee model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Coffee Id {model.Id} is invalid.");
                }
            }
            try
            {
                var coffee = _context.Coffees.Find(model.Id);
                if (coffee == null)
                {
                    return NotFound($"Product not found with id {model.Id}");
                }
                coffee.Name = model.Name;
                coffee.Roaster = model.Roaster;
                coffee.Image = model.Image;
                _context.SaveChanges();
                return Ok("Product details updated.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var coffee = _context.Coffees.Find(id);
                if (coffee == null)
                {
                    return NotFound($"Coffee details not found with id {id}");
                }
                _context.Remove(coffee);
                _context.SaveChanges();
                return Ok("Coffee deleted.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
       
    }
}
