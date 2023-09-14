using System;
using Microsoft.AspNetCore.Mvc;

namespace WATIAPITest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddController : ControllerBase
    {
		[HttpPost]
		public ActionResult AddNumber(InputModel input)
		{
			if(input.num1 == 0 && input.num2 == 0)
			{
				return BadRequest();
			}
			int sum = input.num1 + input.num2;
			return Ok(sum);
		}
	}

	public class InputModel
	{
		public int num1 { get; set; }
        public int num2 { get; set; }
    }
}

