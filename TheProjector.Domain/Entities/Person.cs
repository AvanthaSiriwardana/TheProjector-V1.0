using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheProjector.Domain.Entities
{
	public class Person
	{
		public Person()
		{
			this.ProjectAssignments = new HashSet<ProjectAssignment>();
		}

		[Key()]
		public int Id { get; set; }
		[MinLength(2)]
		public string LastName { get; set; }
		[MinLength(2)]
		public string FirstName { get; set; }
		[MinLength(5)] 
		public string UserName { get; set; }
		[MinLength(7)]
		public string Password { get; set; }

		public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
	}
}
