using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Management_System.Domain.Entities
{
	public abstract class Entity
	{
		public string Id { get; init; } = Guid.NewGuid().ToString();
	}
}
