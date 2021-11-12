using Microsoft.EntityFrameworkCore;

namespace TheProjector.Domain.Entities
{
	public class TheProjectorContext : DbContext
	{
		public TheProjectorContext()
		{

		}

		public TheProjectorContext(DbContextOptions<TheProjectorContext> dbContextOptions)
			: base(dbContextOptions)
		{

		}

		public virtual DbSet<Person> Persons { get; set; }
		public virtual DbSet<Project> Projects { get; set; }
		public virtual DbSet<ProjectAssignment> ProjectAssignment { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SetupTableRelationships(modelBuilder);

			SeedData(modelBuilder);
		}

		private void SetupTableRelationships(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProjectAssignment>()
				.HasKey(t => new { t.PersonId, t.ProjectId });

			modelBuilder.Entity<ProjectAssignment>()
				.HasOne(am => am.Person)
				.WithMany(a => a.ProjectAssignments)
				.HasForeignKey(am => am.PersonId);

			modelBuilder.Entity<ProjectAssignment>()
				.HasOne(am => am.Project)
				.WithMany(m => m.ProjectAssignments)
				.HasForeignKey(am => am.ProjectId);

			modelBuilder.Entity<Project>(entity =>
			{
				entity.ToTable("Projects");

				entity.Property(e => e.Id).UseIdentityColumn();

				entity.Property(e => e.Code)
				.HasColumnType("nvarchar(50)")
				.IsRequired();

				entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnType("nvarchar(50)")
				.IsRequired();

				entity.Property(e => e.Remarks)
				.HasColumnType("nvarchar(max)")
				.IsRequired();

				entity.Property(e => e.Budget)
				.HasColumnType("decimal(18,4)")
				.IsRequired();
			});

			modelBuilder.Entity<Person>(entity =>
			{
				entity.ToTable("Persons");

				entity.Property(e => e.Id).UseIdentityColumn();

				entity.Property(e => e.LastName)
				.HasColumnType("nvarchar(50)")
				.IsRequired();

				entity.Property(e => e.FirstName)
				.HasColumnType("nvarchar(50)")
				.IsRequired();

				entity.Property(e => e.UserName)
				.HasColumnType("nvarchar(200)")
				.IsRequired();

				entity.Property(e => e.Password)
				.HasColumnType("nvarchar(11)")
				.IsRequired();

			});
		}

		private static void SeedData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
		.HasData(
			new Person
			{
				Id = 1,
				FirstName = "Person 1",
				LastName = "Person 1",
				UserName = "Person 1",
				Password = "Password1234",
				ProjectAssignments = null
			},
				new Person
				{
					Id = 2, 
					FirstName = "Person 2",
					LastName = "Person 2",
					UserName = "Person 2",
					Password = "Password123",
					ProjectAssignments = null
				}
				);

			modelBuilder.Entity<Project>()
		.HasData(
			new Project
			{
				Id = 1,
				Code = "Project 1",
				Name = "Project 1",
				Remarks = "Project 1",
				Budget = 152000
			},
				new Project
				{
					Id = 2,
					Code = "Project 2",
					Name = "Project 2",
					Remarks = "Project 2",
					Budget = 75000
				}
				);

			modelBuilder.Entity<ProjectAssignment>()
		.HasData(
			new ProjectAssignment
			{
				PersonId = 1,
				ProjectId = 1
			},
			new ProjectAssignment
			{
				PersonId = 2,
				ProjectId = 2
			}
			);
		}
	}
}