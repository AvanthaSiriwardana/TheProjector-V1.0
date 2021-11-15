using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using TheProjector.Domain.Entities;

namespace TheProjector.Repository
{
	public class ProjectAssignmentRepository : Repository<ProjectAssignment>, IProjectAssignmentRepository
	{
		public ProjectAssignmentRepository(TheProjectorContext context, ILogger logger) :
			base(context, logger)
		{

		}

		public override async Task Add(ProjectAssignment entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "{Repository} Error Assigning person to the project", typeof(ProjectAssignmentRepository));
			}
		}
	}
}
