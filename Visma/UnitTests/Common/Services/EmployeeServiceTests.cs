using Common.Entities;
using Common.Entities.Enums;
using Common.Interfaces;
using Common.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UnitTests.Common.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IEnumerable<Employee> _employees;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeService _sut;

        [SetUp]
        public void Setup()
        {
            _employees = Substitute.For<IEnumerable<Employee>>();
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _sut = new EmployeeService(_employeeRepository);
        }

        [Test]
        public void CeoExists_Should_ReturnTrue_When_Repository_ReturnsTrue()
        {
            _employeeRepository.CeoExists().Returns(true);

            Assert.IsTrue(_sut.CeoExists());
        }

        [Test]
        public void FindByBossId_Should_ReturnEmployees_When_Repository_ReturnsEmployees()
        {
            var guid = Arg.Any<Guid>();

            _employeeRepository.FindByBossId(guid).Returns(_employees);

            var result = _sut.FindByBossId(guid);

            Assert.IsTrue(result == _employees);
        }

        [Test]
        public void FindByNameAndBirthdate_Should_ReturnEmployees_When_Repository_ReturnsEmployees()
        {
            var name = Arg.Any<string>();
            var birthdayFrom = Arg.Any<DateTime>();
            var birthdayTo = Arg.Any<DateTime>();

            _employeeRepository.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo).Returns(_employees);

            var result = _sut.FindByNameAndBirthdate(name, birthdayFrom, birthdayTo);

            Assert.IsTrue(result == _employees);
        }

        [Test]
        public void FindByRole_Should_ReturnEmployees_When_Repository_ReturnsEmployees()
        {
            var roleName = Arg.Any<string>();

            _employeeRepository.FindByRole(roleName).Returns(_employees);

            var result = _sut.FindByRole(roleName);

            Assert.IsTrue(result == _employees);
        }

        [Test]
        public void UpdateSalary_Should_Return1_When_Repository_Returns1()
        {
            var id = Arg.Any<Guid>();
            var salary = Arg.Any<double>();

            _employeeRepository.UpdateSalary(id, salary).Returns(1);

            var result = _sut.UpdateSalary(id, salary);

            Assert.IsTrue(result == 1);
        }

        [Test]
        public void GetEmployeeCountAndAverageSalaryByRole_Should_ReturnResult_When_RoleExists()
        {
            var expected = new EmployeeCountAndAverageSalaryResult { Role = Role.CEO, Count = 2, SalaryAverage = 400d };
            var expectedList = new List<EmployeeCountAndAverageSalaryResult> { expected };
            var entry1 = new Employee() { Role = 0, Salary = 200 };
            var entry2 = new Employee() { Role = 0, Salary = 600 };
            var employeeList = new List<Employee> { entry1, entry2 };

            _employeeRepository.GetAll().Returns(employeeList);

            var result = _sut.GetEmployeeCountAndAverageSalaryByRole(Role.CEO);

            Assert.AreEqual(JsonSerializer.Serialize(expectedList), JsonSerializer.Serialize(result));
        }
    }
}
