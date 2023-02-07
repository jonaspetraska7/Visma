using Common.Entities;
using Common.Interfaces;
using Common.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Visma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetById")]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.GetById(id));
        }

        [HttpGet("FindByBossId")]
        public IActionResult FindByBossId(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.FindByBossId(id));
        }

        [HttpGet("FindByNameAndBirthdate")]
        public IActionResult FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo));
        }

        [HttpPost("Add")]
        [ServiceFilter(typeof(AddEmployeeActionFilter))]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Add(employee));
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Update(employee));
        }

        [HttpPut("UpdateSalary")]
        public IActionResult UpdateSalary(Guid id, double salary)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.UpdateSalary(id, salary));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Remove(id));
        }
    }
}
