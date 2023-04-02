using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly DataContext _context;
        public PurchaseController(DataContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Purchase>>> Get()
        {
            return Ok(await _context.Purchases.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<Purchase>> Get(int id)
        {
            var dbPurchase = await _context.Purchases.FindAsync(id);
            if (dbPurchase == null)
            {
                return BadRequest("Purchase not found");
            }

            return Ok(dbPurchase);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(Purchase purchase)
        {
            if (purchase == null)
            {
                return BadRequest();
            }
            _context.Purchases.Add(purchase); 
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put(Purchase purchase)
        {
            var dbPurchase = await _context.Purchases.FindAsync(purchase.Id);
            if (dbPurchase == null) {
                return BadRequest("Purchase not found");
            }

            dbPurchase.Id = purchase.Id;
            dbPurchase.Description = purchase.Description;
            dbPurchase.Date = purchase.Date;
            dbPurchase.Price = purchase.Price;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbPurchase = await _context.Purchases.FindAsync(id);
            if (dbPurchase == null)
            {
                return BadRequest("Purchase not found");
            }

            _context.Purchases.Remove(dbPurchase);
            await _context.SaveChangesAsync();
            return Ok();
        } 
    }
}

