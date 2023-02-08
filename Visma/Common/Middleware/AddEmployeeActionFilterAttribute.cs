using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;
using Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Middleware
{
    public class AddEmployeeActionFilterAttribute : ServiceFilterAttribute 
    {
        public AddEmployeeActionFilterAttribute() : base(typeof(AddEmployeeActionFilter))
        {

        }
    }

    public class AddEmployeeActionFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeActionFilter(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var employee = (Employee?) context.ActionArguments.First().Value;

            if (employee == null || employee.Role != Role.CEO)
            {
                return;
            }

            if (_employeeService.CeoExists())
            {
                context.ModelState.AddModelError(nameof(employee.Role), ValidationMessages.Ceo);
            }
        }
    }
}

