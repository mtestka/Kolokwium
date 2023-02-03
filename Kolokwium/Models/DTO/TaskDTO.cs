using System;
namespace Kolokwium.Models.DTO
{
	public class TaskDTO
	{
		public int IdTask { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public TaskType TaskType { get; set; }

		public TaskDTO(Models.Task Task)
		{
			IdTask = Task.IdTask;
			Name = Task.Name;
			Description = Task.Description;
			Deadline = Task.Deadline;
			TaskType = Task.TaskType;
		}
	}
}

