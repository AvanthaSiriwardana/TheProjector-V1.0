using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Repository
{
	public interface IUnitOfWork
	{
		IPersonRepository Person { get; }
		IProjectRepository Project { get; }

		Task CompleteAsync();
		void Dispose();
	}
}
