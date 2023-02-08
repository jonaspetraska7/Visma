using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;
using Common.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Common.Middleware
{
    [TestFixture]
    public class AddEmployeeActionFilterTests
    {
        private Employee _employee;
        private IEmployeeService _employeeService;
        private ActionExecutingContext _actionExecutingContext;
        private AddEmployeeActionFilter _sut;

        [SetUp]
        public void Setup()
        {
            _employee = Substitute.For<Employee>();
            _employeeService = Substitute.For<IEmployeeService>();
            _actionExecutingContext = GetContext();
            _sut = new AddEmployeeActionFilter(_employeeService);
        }

        [Test]
        public void AddEmployeeActionFilter_Should_Add_Error_When_Ceo_Exists()
        {
            _employee.Role = Role.CEO;
            _actionExecutingContext.ActionArguments.Add("any", _employee);
            _employeeService.CeoExists().Returns(true);

            _sut.OnActionExecuting(_actionExecutingContext);

            Assert.That(_actionExecutingContext.ModelState.ErrorCount, Is.EqualTo(1));
        }

        private ActionExecutingContext GetContext()
        {
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();
            var actionContext = new ActionContext(httpContext, routeData, actionDescriptor, modelState);
            var filters = new List<IFilterMetadata>();
            var actionArguments = Substitute.For<Dictionary<string, object?>>();
            var controller = Substitute.For<Controller>();
            var context = new ActionExecutingContext(actionContext, filters, actionArguments, controller);

            return context;
        }
    }
}
