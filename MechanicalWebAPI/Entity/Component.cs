namespace MechanicalWebAPI.Entity
{
	public class Component
	{
		public int Id { get; set; }
		public string ComponentName { get; set; }
		public string Quantity { get; set; }
		public List<ComponentOperation> componentOperation { get; set; }
		public string Remarks { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
	}
}
