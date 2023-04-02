
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        // GET: /<controller>/\
        private readonly DataContext _context;
        public CoffeeController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Coffee coffee)
        {
            if (coffee == null)
            {
                return BadRequest();
            }
            _context.Coffees.Add(coffee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Coffees.ToListAsync());
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Coffee>>> Get()
        {
            return Ok(await _context.Coffees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> Put(Coffee coffee)
        {
            var dbCoffee = await _context.Coffees.FindAsync(coffee.Id);
            if (dbCoffee == null)
            {
                return BadRequest("Coffee not found");
            }

            dbCoffee.Id = coffee.Id;
            dbCoffee.Name = coffee.Name;
            dbCoffee.Date = coffee.Date;
            dbCoffee.Price = coffee.Price;

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}

