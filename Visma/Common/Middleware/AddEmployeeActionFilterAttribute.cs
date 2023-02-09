using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Common.Middleware
{
    public class AddEmployeeActionFilterAttribute : ServiceFilterAttribute 
    {
        public AddEmployeeActionFilterAttribute() : base(typeof(AddEmployeeActionFilter))
        {

        }
    }
}

