using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
	public class Task
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTask { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public int IdTeam { get; set; }
        [ForeignKey("IdTeam")]
        public virtual Project Team { get; set; }
		public int IdTaskType { get; set; }
        [ForeignKey("IdTaskType")]
        public virtual TaskType TaskType { get; set; }
		public int IdAssignedTo { get; set; }
        [ForeignKey("IdAssignedTo")]
        public virtual TeamMember AssignedTo { get; set; }
		public int IdCreator { get; set; }
        [ForeignKey("IdCreator")]
        public virtual TeamMember Creator { get; set; }

		public Task()
		{
		}
	}
}

