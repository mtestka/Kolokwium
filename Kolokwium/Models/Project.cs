using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
	public class Project
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTeam { get; set; }
		public string Name { get; set; }
		public DateTime Deadline { get; set; }
		public virtual List<Task> Tasks { get; set; }

		public Project()
		{
		}
	}
}

