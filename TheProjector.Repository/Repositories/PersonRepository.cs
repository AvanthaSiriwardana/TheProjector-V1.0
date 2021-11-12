using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;
using TheProjector.Repository;

namespace TheProjector.Repository
{
	public class PersonRepository : Repository<Person>, IPersonRepository
	{
		public PersonRepository(TheProjectorContext context, ILogger logger) : 
			base(context, logger)
		{

		}

		public override async Task Add(Person entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "{Repository} Error Adding Person", typeof(PersonRepository));
			}
		}
	}
}
