using System.ComponentModel.DataAnnotations;

namespace MechanicalWebAPI.Entity
{
	public class Machine
	{
		[Key]
		public int Id { get; set; }
		public string MachineName { get; set; }
		public string Remarks { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
	}
}
