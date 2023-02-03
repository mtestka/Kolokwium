using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models
{
	public class TeamMember
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTeamMember { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public virtual List<Models.Task> Tasks { get; set; }

		public TeamMember()
		{

		}
	}
}

