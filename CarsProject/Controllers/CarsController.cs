using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsProject.Data;
using ModelStructure;

namespace CarsProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            var dbCar = _context.Cars.Find(car.Id);

            var fuel = _context.Fuels.Where(x => x.Id == car.FuelId).FirstOrDefault();
            dbCar.Fuel = fuel;
            dbCar.FuelId = fuel.Id;

            var brand = _context.Brands.Where(x => x.Id == car.BrandId).FirstOrDefault();
            dbCar.Brand = brand;
            dbCar.BrandId = brand.Id;

            var engine = _context.Engines.Where(x => x.Id == car.BrandId).FirstOrDefault();
            dbCar.Engine = engine;
            dbCar.EngineId = engine.Id;

            _context.Cars.Update(dbCar);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }
           

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {

            var fuel = _context.Fuels.Where(x => x.Id == car.FuelId).FirstOrDefault();
            car.Fuel = fuel;
            car.FuelId = fuel.Id;

            var brand = _context.Brands.Where(x => x.Id == car.BrandId).FirstOrDefault();
            car.Brand = brand;
            car.BrandId = brand.Id;

            var engine = _context.Engines.Where(x => x.Id == car.BrandId).FirstOrDefault();
            car.Engine = engine;
            car.EngineId = engine.Id;  

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
