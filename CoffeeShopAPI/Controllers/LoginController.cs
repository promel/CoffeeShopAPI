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
    public class LoginController : ControllerBase
    {
        // GET: /<controller>/\
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<User>> Get(User user)
        {
            var dbUser = await _context.Users.FindAsync(user.Email);
            if (dbUser?.Password == user.Password && dbUser?.Email == user.Email)
            {
                return BadRequest("Purchase not found");
            }
            return Ok();
        }
    }
}