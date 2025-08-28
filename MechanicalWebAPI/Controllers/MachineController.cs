using MechanicalWebAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace MechanicalWebAPI.Controllers
{
	[ApiController]
	public class MachineController : Controller
	{
		[HttpGet("Index")]
		public IActionResult Index()
		{
			return Ok(1);
		}
		[HttpPost("MachineAddEdit")]
		public IActionResult MachineAddEdit([FromBody]MachineAddEditInput input)
		{
			if (input == null) return BadRequest("Invalid input");

			object result = SQLManager.ExecuteNonQuery(input, "Machine_AddEdit");
			return Ok(new { result, success = true, message = "Machine saved successfully" });
		}
		[HttpPost("MachineDelete")]
		public IActionResult MachineDelete([FromBody] MachineDeleteInput input)
		{
			if (input == null) return BadRequest("Invalid input");

			object result = SQLManager.DeleteById(input, "Machine_DeleteById");
			return Ok(new { result, success = true, message = "Machine Deleted successfully" });
		}
		[HttpPost("MachineGetListing")]
		public object MachineGetListing([FromBody] MachineGetListing input)
		{
			if (input == null) return BadRequest("Invalid input");
			
			return SQLManager.GetListing(input, "Machine_GetListing");
		}

		[HttpPost("MachineGetById")]
		public object MachineGetById([FromBody] MachineGetById input)
		{
			if (input == null) return BadRequest("Invalid input");

			return SQLManager.GetListing(input, "Machine_GetById");
		}
		[HttpPost("MachineGetByName")]
		public object MachineGetByName([FromBody] MachineGetByName input)
		{
			if (input == null) return BadRequest("Invalid input");

			return SQLManager.GetListing(input, "Machine_GetByName");
		}
	}

	public class MachineDeleteInput
	{
		public int Id { get; set; }
	}

	public class MachineGetByName
	{
		public string MachineName { get; set; }
	}

	public class MachineGetById
	{
		public int Id { get; set; }
	}

	public class MachineGetListing { }

	public class MachineAddEditInput
	{
		public string MachineName { get; set; }
		public string Remarks { get; set; }
		public bool IsActive { get; set; }
	}
}
