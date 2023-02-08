using Common.Entities;
using Common.Interfaces;
using Common.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UnitTests.Common.Services
{
    [TestFixture]
    public class GenericRepositoryBasedServiceTests
    {
        private Employee _employee;
        private IEnumerable<Employee> _employees;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeService _sut;

        [SetUp]
        public void Setup()
        {
            _employee = Substitute.For<Employee>();
            _employees = Substitute.For<IEnumerable<Employee>>();
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _sut = new EmployeeService(_employeeRepository);
        }

        [Test]
        public void Add_Should_Return1_When_Repository_Returns1()
        {
            _employeeRepository.Add(_employee).Returns(1);

            var result = _sut.Add(_employee);

            Assert.IsTrue(result == 1);
        }

        [Test]
        public void Find_Should_ReturnEmployees_When_Repository_ReturnsEmployees()
        {
            var expression = Arg.Any<Expression<Func<Employee, bool>>>();

            _employeeRepository.Find(expression).Returns(_employees);

            var result = _sut.Find(expression);

            Assert.IsTrue(result == _employees);
        }

        [Test]
        public void GetAll_Should_ReturnEmployees_When_Repository_ReturnsEmployees()
        {
            _employeeRepository.GetAll().Returns(_employees);

            var result = _sut.GetAll();

            Assert.IsTrue(result == _employees);
        }

        [Test]
        public void GetById_Should_ReturnEmployee_When_Repository_ReturnsEmployee()
        {
            var id = Arg.Any<Guid>();

            _employeeRepository.GetById(id).Returns(_employee);

            var result = _sut.GetById(id);

            Assert.IsTrue(result == _employee);
        }

        [Test]
        public void Update_Should_Return1_When_Repository_Returns1()
        {
            _employeeRepository.Update(_employee).Returns(1);

            var result = _sut.Update(_employee);

            Assert.IsTrue(result == 1);
        }

        [Test]
        public void Remove_Should_Return1_When_Repository_Returns1()
        {
            var guid = Arg.Any<Guid>();

            _employeeRepository.Remove(guid).Returns(1);

            var result = _sut.Remove(guid);

            Assert.IsTrue(result == 1);
        }
    }
}
