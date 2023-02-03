using System;
namespace Kolokwium.Models.DTO
{
	public class TaskPostDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public int IdTeam { get; set; }
		public int IdAssignedTo { get; set; }
		public int IdCreator { get; set; }
		public TaskType TaskType { get; set; }

		public TaskPostDTO()
		{
		}
	}
}

