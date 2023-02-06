using LinqToDB.Mapping;

namespace Common.Entities
{
    public class Employee
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int BossId { get; set; }
        public Employee Boss { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
