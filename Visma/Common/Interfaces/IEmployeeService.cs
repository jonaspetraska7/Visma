using Common.Entities;
using Common.Entities.Enums;

namespace Common.Interfaces
{
    public interface IEmployeeService : IEmployeeRepository
    {
        EmployeeCountAndAverageSalaryResult GetEmployeeCountAndAverageSalaryByRole(Role role);
    }
}
