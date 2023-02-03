using System;
namespace Kolokwium.Models.DTO
{
	public class ProjectDTO
	{
		public int IdTeam { get; set; }
		public string Name { get; set; }
		public DateTime Deadline { get; set; }
		public List<TaskDTO> Tasks { get; set; }

		public ProjectDTO(Project project)
		{
			IdTeam = project.IdTeam;
			Name = project.Name;
			Deadline = project.Deadline;
			Tasks = project.Tasks.Select(a => new TaskDTO(a)).ToList();
		}
	}
}

