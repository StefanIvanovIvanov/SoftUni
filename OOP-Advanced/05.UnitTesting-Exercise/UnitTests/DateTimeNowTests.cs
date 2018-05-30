using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using _09.DateTme.Now.AddDays;

namespace UnitTests
{
    [TestFixture]
    public class AddDaysTests
    {
        private DateTimeTestClass dt;

        [SetUp]
        public void Initialization()
        {
            this.dt = new DateTimeTestClass();
        }

        [Test]
        public void ReturnCurrentDate()
        {
            var expectedValue = DateTime.Now.Date;

            Assert.AreEqual(expectedValue, this.dt.Now().Date);
        }

        [Test]
        public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
        {
            var testDate = new DateTime(2000, 10, 31);
            var expectedDate = new DateTime(2000, 11, 1);

            testDate = testDate.AddDays(1);

            Assert.AreEqual(expectedDate, testDate);
        }
    }
}
