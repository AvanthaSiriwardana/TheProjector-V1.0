using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

		public override async Task<IEnumerable<Person>> Find(Expression<Func<Person, bool>> predicate)
		{
			try
			{
				return (IEnumerable<Person>)await _dbSet.FindAsync(predicate);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "{Repository} Error Retrieving Members ", typeof(PersonRepository));
			}

			return null;
		}
	}
}
