using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;
using TheProjector.Repository;

namespace TheProjector.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected TheProjectorContext _context;
		internal DbSet<TEntity> _dbSet = null;
		protected readonly ILogger _logger;

		public Repository(TheProjectorContext context, ILogger logger)
		{
			_context = context;
			_logger = logger;
			_dbSet = context.Set<TEntity>();
			_context.Persons.Include(x => x.ProjectAssignments).ToList();
			_context.Projects.Include(x => x.ProjectAssignments).ToList();
		}

		public virtual async Task Add(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public virtual async Task<TEntity> Get(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbSet.ToListAsync();
		}

		public void Remove(TEntity entity)
		{
			_dbSet.Remove(entity);
		}
	}
}