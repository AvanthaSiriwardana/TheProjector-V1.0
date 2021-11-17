using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheProjector.Domain.Entities
{
	public class Project
	{
		public Project()
		{
			this.ProjectAssignments = new HashSet<ProjectAssignment>();
		}
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remarks { get; set; }
		public decimal Budget { get; set; }

		public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
	}
}
