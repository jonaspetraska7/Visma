using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;

namespace Common.Services
{
    public class EmployeeService : GenericRepositoryBasedService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeCountAndAverageSalaryResult> GetEmployeeCountAndAverageSalaryByRole(Role role)
        {
            var employees = _employeeRepository.GetAll();
            var employeeCountAndAvgSalaryByRole = employees.GroupBy(x => x.Role, (key, g) =>
                new EmployeeCountAndAverageSalaryResult() { Role = key, Count = g.Count(), SalaryAverage = g.Average(x => x.Salary) }).Where(x => x.Role == role).ToList();

            return employeeCountAndAvgSalaryByRole;
        }

        public bool CeoExists() => _employeeRepository.CeoExists();

        public IEnumerable<Employee> FindByBossId(Guid bossId) => _employeeRepository.FindByBossId(bossId);

        public IEnumerable<Employee> FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo) => _employeeRepository.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo);

        public IEnumerable<Employee> FindByRole(string roleName) => _employeeRepository.FindByRole(roleName);

        public int UpdateSalary(Guid id, double salary) => _employeeRepository.UpdateSalary(id, salary);
    }
}
