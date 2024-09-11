using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Management_System.Domain.Entities
{
	public class User : IdentityUser 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email {  get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public ICollection<Visit> Visits { get; set; }
	}
}
