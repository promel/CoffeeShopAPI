using System;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController: ControllerBase
    {
        private readonly DataContext _context;
        public RoleController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

