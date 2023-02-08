using Common.Entities;
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

namespace UnitTests.Common.Middleware
{
    [TestFixture]
    public class ModelStateIsValidActionFilterAttributeTests
    {
        private ActionExecutingContext _actionExecutingContext;
        private ModelStateIsValidActionFilterAttribute _sut;

        [SetUp]
        public void Setup()
        {
            _actionExecutingContext = GetContext();
            _sut = new ModelStateIsValidActionFilterAttribute();
        }

        [Test]
        public void Invalid_ModelState_Should_Return_BadRequestObjectResult()
        {
            _actionExecutingContext.ModelState.AddModelError("", "error");

            _sut.OnActionExecuting(_actionExecutingContext);

            Assert.That(_actionExecutingContext.Result, Is.TypeOf<BadRequestObjectResult>());
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
