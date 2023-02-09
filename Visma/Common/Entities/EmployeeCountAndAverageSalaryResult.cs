using Common.Entities.Enums;

namespace Common.Entities
{
    public class EmployeeCountAndAverageSalaryResult
    {
        public Role Role { get; set; }
        public int Count { get; set; }
        public double SalaryAverage { get; set; }
    }
}
