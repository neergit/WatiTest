using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WATIAPITest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddController : ControllerBase
    {
        private readonly StorageContext _context;

        public AddController(StorageContext context)
		{
			_context = context;
		}

        [HttpPost]
		public ActionResult AddNumber(InputModel input)
		{
			if(input.num1 == 0 && input.num2 == 0)
			{
				return BadRequest();
			}
			int sum = input.num1 + input.num2;
			Storage data = new Storage
			{
				num1 = input.num1,
				num2 = input.num2,
				sum = sum
			};

			_context.NumberSumStorages.Add(data);
			_context.SaveChanges();
			return Ok(data);
		}
	}

	public class InputModel
	{
		public int num1 { get; set; }
        public int num2 { get; set; }
    }

	public class Storage
	{
		public int Id { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int sum { get; set; }
    }

	public class StorageContext : DbContext
	{
		public StorageContext(DbContextOptions<StorageContext> options) : base(options) { }

		public DbSet<Storage> NumberSumStorages { get; set; }
	}
}

