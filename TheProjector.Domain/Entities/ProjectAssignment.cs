using System;
using System.Collections.Generic;
using System.Text;

namespace TheProjector.Domain.Entities
{
	public class ProjectAssignment
	{
		public int ProjectId { get; set; }
		public Project Project { get; set; }

		public int PersonId { get; set; }
		public Person Person { get; set; }
	}
}
