using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;
using TheProjector.Repository;

namespace TheProjector.Repository
{
	public class ProjectRepository : Repository<Project>, IProjectRepository
	{
		public ProjectRepository(TheProjectorContext context, ILogger logger) : 
			base(context, logger)
		{

		}

		public override async Task Add(Project entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "{Repository} Error Adding Project", typeof(ProjectRepository));
			}
		}

		public override async Task<IEnumerable<Project>> GetAll()
		{
			try
			{
				return await _dbSet.ToListAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "{Repository} Error Loading Projects", typeof(ProjectRepository));
				return new List<Project>();
			}
		}
	}
}
