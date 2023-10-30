﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public DateTime BirthDate { get; set; }
		public string Role { get; set; } = null!;
		public string Email { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public List<Order>? Orders { get; set; }
		public List<Item>? Item { get; set; }
	}
}