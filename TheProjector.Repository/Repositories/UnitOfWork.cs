using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;

namespace TheProjector.Repository
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly TheProjectorContext _context;
		private readonly ILogger _logger;

		public IPersonRepository Person { get; private set; }
		public IProjectRepository Project { get; private set; }
		public IProjectAssignmentRepository ProjectAssignmentRepository { get; private set; }

		public UnitOfWork(TheProjectorContext context, ILoggerFactory loggerFactory)
		{
			_context = context;
			_logger = loggerFactory.CreateLogger("TheProjector.Logs");

			Person = new PersonRepository(_context, _logger);
			Project = new ProjectRepository(_context, _logger);
			ProjectAssignmentRepository = new ProjectAssignmentRepository(_context, _logger);
		}

		public async Task CompleteAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
