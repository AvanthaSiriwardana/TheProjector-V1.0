using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Services
{
	public interface IPersonService
	{
		Task<ResponseBase> Add(PersonRequest request);
	}
}
