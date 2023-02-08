using Common.Entities;
using Common.Interfaces;
using Common.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Visma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.GetById(id));
        }

        [HttpGet("FindByBossId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FindByBossId(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.FindByBossId(id));
        }

        [HttpGet("FindByNameAndBirthdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo));
        }

        [HttpPost("Add")]
        [AddEmployeeActionFilterAttribute]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Add(employee));
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Update(employee));
        }

        [HttpPut("UpdateSalary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateSalary(Guid id, double salary)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.UpdateSalary(id, salary));
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_employeeService.Remove(id));
        }
    }
}
