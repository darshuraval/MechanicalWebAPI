using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MechanicalWebAPI.Entity
{
	public class ComponentOperation
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public MachineOperation MachineOperation { get; set; }

		public double OperationTime { get; set; }  // minutes
		public string Remarks { get; set; }

		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}

	//public class ComponentOperations
	//{
	//	List<ComponentOperation> list { get; set; }
	//	public ComponentOperations()
	//	{
	//		AddComponentOperation("Component A - Turning", new Dictionary<MachineOperation, double> { { new MachineOperation { Id = 1, MachineOperationName = "Lathe Turning", MachineId = 1, OperationId = 1, SetupTime = 15 }, 30 } }, 30);
	//		AddComponentOperation("Component B - Drilling", new Dictionary<MachineOperation, double> { { new MachineOperation { Id = 2, MachineOperationName = "Milling Drilling", MachineId = 2, OperationId = 3, SetupTime = 20 }, 45 } }, 45);
	//		AddComponentOperation("Component C - Grinding", new Dictionary<MachineOperation, double> { { new MachineOperation { Id = 4, MachineOperationName = "Grinding HeavyDuty", MachineId = 4, OperationId = 4, SetupTime = 25 }, 60 } }, 60);
	//		AddComponentOperation("Component D - Cutting", new Dictionary<MachineOperation, double> { { new MachineOperation { Id = 5, MachineOperationName = "Cutting Manual", MachineId = 5, OperationId = 5, SetupTime = 5 }, 15 } }, 15);
	//		AddComponentOperation("Component E - Welding", new Dictionary<MachineOperation, double> { { new MachineOperation { Id = 6, MachineOperationName = "Welding Manual", MachineId = 6, OperationId = 6, SetupTime = 30 }, 50 } }, 50);
	//	}
	//	public void AddComponentOperation(string name, Dictionary<MachineOperation, double> machineOperations, double operationTime)
	//	{
	//		list.Add(new ComponentOperation { Name = name, MachineOperation = machineOperations, OperationTime = operationTime });
	//	}
	//	public void RemoveComponentOperation(int id)
	//	{
	//		var componentOperation = list.Find(m => m.Id == id);
	//		if (componentOperation != null)
	//		{
	//			list.Remove(componentOperation);
	//		}
	//	}
	//	public ComponentOperation GetComponentOperation(int id)
	//	{
	//		return list.Find(m => m.Id == id);
	//	}
	//	public List<ComponentOperation> GetAllComponentOperations()
	//	{
	//		return list;
	//	}
	//}

}
