using System;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;

namespace CoffeeShopAPI.Models
{
	public class User
	{
		public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public int RoleId { get; set; } // Required foreign key property
        public Role? Role { get; set; }

        public ICollection<Purchase> Purchases{ get; } = new List<Purchase>();
    }
}