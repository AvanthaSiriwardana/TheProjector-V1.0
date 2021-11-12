using System;
using System.Collections.Generic;
using System.Text;

namespace TheProjector.Services
{
	public class ProjectRequest
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remarks { get; set; }
		public decimal Budget { get; set; }
	}
}
