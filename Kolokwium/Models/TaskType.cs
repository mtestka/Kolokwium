using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
	public class TaskType
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTaskType { get; set; }
		public string Name { get; set; }

		public TaskType()
		{
		}
	}
}

