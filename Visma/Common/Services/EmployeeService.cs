using Common.Entities;
using Common.Interfaces;

namespace Common.Services
{
    public abstract class EmployeeService : GenericRepositoryBasedService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CeoExists() => _employeeRepository.CeoExists();

        public IEnumerable<Employee> FindByBossId(Guid bossId) => _employeeRepository.FindByBossId(bossId);

        public IEnumerable<Employee> FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo) => _employeeRepository.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo);

        public IEnumerable<Employee> FindByRole(string roleName) => _employeeRepository.FindByRole(roleName);

        public int UpdateSalary(Guid id, double salary) => _employeeRepository.UpdateSalary(id, salary);
    }
}
