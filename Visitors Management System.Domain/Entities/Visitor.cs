using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Management_System.Domain.Entities
{
	public class Visitor : Entity
	{
		
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string? Company { get; set; }
		public string Purpose { get; set; }
		public DateTime CheckInTime { get; set; }
		public DateTime? CheckOutTime { get; set; }
		public string PersonVisitedId { get; set; }
		public ICollection<Visit> Visits { get; set; }
	}
}

