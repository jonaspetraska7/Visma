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
}

