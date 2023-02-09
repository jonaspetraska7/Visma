using Common.Entities;
using Common.Entities.Enums;

namespace Common.Interfaces
{
    public interface IEmployeeService : IEmployeeRepository
    {
        List<EmployeeCountAndAverageSalaryResult> GetEmployeeCountAndAverageSalaryByRole(Role role);
    }
}
