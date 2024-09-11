using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Management_System.Domain.Entities
{
	public class Visit : Entity
	{
		public Visitor Visitor { get; set; }
		public DateTime CheckInTime { get; set; }
		public DateTime? CheckOutTime { get; set; }
		public int PersonVisitedID { get; set; }
		public User PersonVisited { get; set; }
	}
}
