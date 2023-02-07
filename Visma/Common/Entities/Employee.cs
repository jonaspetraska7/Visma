using Common.Entities.Enums;
using Common.Entities.Attributes;
using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Employee : Entity
    {
        [Required]
        [StringLength(50)]
        [FirstNameValidation]
        [Column(CanBeNull = false)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column(CanBeNull = false)]
        public string LastName { get; set; }

        [Required]
        [BirthdateValidation]
        [Column(CanBeNull = false)]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmploymentDateValidation]
        [Column(CanBeNull = false)]
        public DateTime EmploymentDate { get; set; }

        [BossValidation]
        public Guid? BossId { get; set; }

        public virtual Employee Boss { get; set; }

        [Required]
        [Column(CanBeNull = false)]
        public string Address { get; set; }

        [Required]
        [SalaryValidation]
        [Column(CanBeNull = false)]
        public double Salary { get; set; }

        [Required]
        [Column(CanBeNull = false)]
        public Role Role { get; set; }
    }
}
