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
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_employeeService.GetById(id));
        }

        [HttpGet("FindByBossId")]
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FindByBossId(Guid id)
        {
            return Ok(_employeeService.FindByBossId(id));
        }

        [HttpGet("FindByNameAndBirthdate")]
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo)
        {
            return Ok(_employeeService.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo));
        }

        [HttpPost("Add")]
        [ModelStateIsValidActionFilter]
        [AddEmployeeActionFilterAttribute]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromBody] Employee employee)
        {
            return Ok(_employeeService.Add(employee));
        }

        [HttpPut("Update")]
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] Employee employee)
        {
            return Ok(_employeeService.Update(employee));
        }

        [HttpPut("UpdateSalary")]
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateSalary(Guid id, double salary)
        {
            return Ok(_employeeService.UpdateSalary(id, salary));
        }

        [HttpDelete("Delete")]
        [ModelStateIsValidActionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            return Ok(_employeeService.Remove(id));
        }
    }
}
