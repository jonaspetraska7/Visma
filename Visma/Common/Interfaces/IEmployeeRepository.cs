using Common.Entities;

namespace Common.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo);
        IEnumerable<Employee> FindByBossId(Guid bossId);
        IEnumerable<Employee> FindByRole(string roleName);
        int UpdateSalary(Guid id, double salary);
    }
}
