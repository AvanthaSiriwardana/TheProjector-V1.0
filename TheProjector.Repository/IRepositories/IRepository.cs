using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Repository
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<TEntity> Get(int id);

		Task<IEnumerable<TEntity>> GetAll();

		Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

		Task Add(TEntity entity);

		Task Remove(TEntity entity);
	}
}