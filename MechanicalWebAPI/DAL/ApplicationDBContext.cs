using MechanicalWebAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWebAPI.DAL
{
	public class ApplicationDBContext : DbContext
	{
		
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

		public DbSet<Machine> Machines { get; set; }
		public DbSet<Operation> Operations { get; set; }
		public DbSet<MachineOperation> MachineOperations { get; set; }
		public DbSet<ComponentOperation> ComponentOperations { get; set; }

	}
}
