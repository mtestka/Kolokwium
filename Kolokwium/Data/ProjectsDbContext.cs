using System;
using System.Numerics;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Data
{
	public class ProjectsDbContext:DbContext
	{
		public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options):base(options)
		{

		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<Models.Task> Tasks { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }
		public DbSet<TeamMember> TeamMembers { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(d => new { d.IdTeam });
            modelBuilder.Entity<Models.Task>()
                .HasKey(d => new { d.IdTask });
            modelBuilder.Entity<TaskType>()
                .HasKey(d => new { d.IdTaskType });
            modelBuilder.Entity<TeamMember>()
                .HasKey(d => new { d.IdTeamMember });

            modelBuilder.Entity<Models.Task>()
                .HasOne<TeamMember>(s => s.Creator)
                .WithMany(ta => ta.Tasks)
                .HasForeignKey(u => u.IdCreator)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

