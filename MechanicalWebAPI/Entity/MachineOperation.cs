using System.ComponentModel.DataAnnotations;

namespace MechanicalWebAPI.Entity
{
	public class MachineOperation
	{
		[Key]
		public int Id { get; set; }
		public string MachineOperationName { get; set; }

		// Foreign Keys
		//public int MachineId { get; set; }
		//public int OperationId { get; set; }

		// Navigation properties (optional, if you use EF Core later)
		public Machine Machine { get; set; }
		public Operation Operation { get; set; }

		// Industry data
		public double SetupTime { get; set; }   // Mostly fixed per Machine+Operation
		public string Remarks { get; set; }
		public DateTime ModifiedDate { get; set; } = DateTime.Now;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
