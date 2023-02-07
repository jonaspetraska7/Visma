using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;
using Common.Resources;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Common.Middleware
{
    public class AddEmployeeActionFilter : ActionFilterAttribute
    {
        private readonly IEmployeeService _employeeService;
        public AddEmployeeActionFilter(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var employee = (Employee) actionContext.ActionArguments.First().Value;

            if(employee == null || employee.Role != Role.CEO)
            {
                return;
            }

            if (_employeeService.CeoExists())
            {
                actionContext.ModelState.AddModelError(nameof(employee.Role), ValidationMessages.Ceo);
            }
        }
    }
}

