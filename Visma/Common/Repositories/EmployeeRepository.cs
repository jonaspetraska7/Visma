using Common.Data;
using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;
using LinqToDB;

namespace Common.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VismaDataConnection context) : base(context)
        {
            
        }

        public IEnumerable<Employee> FindByBossId(Guid bossId)
        {
            return Find(x => x.BossId == bossId);
        }

        public IEnumerable<Employee> FindByNameAndBirthdate(string name, DateTime birthdayFrom, DateTime birthdayTo)
        {
            return Find(x => x.FirstName == name).Where(x => x.Birthdate >= birthdayFrom && x.Birthdate <= birthdayTo);
        }

        public IEnumerable<Employee> FindByRole(string roleName)
        {
            return Find(x => Enum.GetName(typeof(Role), x.Role) == roleName);
        }

        public int UpdateSalary(Guid id, double salary)
        {
            if(salary < 0)
            {
                return -1;
            }
            return _context.Employees.Where(x => x.Id == id).Set(x => x.Salary, salary).Update();
        }

        public bool CeoExists()
        {
            return _context.Employees.Any(x => x.Role == Role.CEO);
        }
    }
}
