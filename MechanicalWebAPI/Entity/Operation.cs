using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace MechanicalWebAPI.Entity
{
	public class Operation
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }  // e.g. Turning, Drilling, Milling
		public string Type { get; set; }  // e.g. Manual, CNC, HeavyDuty
		public string Remarks { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
		public DateTime ModifiedDate { get; set; } = DateTime.Now;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
