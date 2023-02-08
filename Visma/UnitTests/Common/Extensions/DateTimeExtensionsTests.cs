using Common.Extensions;
using NUnit.Framework;
using System;

namespace UnitTests.Common.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void Age_Should_Return1_When_DateTime_IsOneYearEarlierThanToday()
        {
            var today = DateTime.Today;
            var birthDay = new DateTime(today.Year - 1, today.Month, today.Day);

            var result = birthDay.Age();

            Assert.IsTrue(result == 1);
        }
    }
}
