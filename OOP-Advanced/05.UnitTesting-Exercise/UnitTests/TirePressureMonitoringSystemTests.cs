using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;
using _10.TirePressureMonitoringSystem;

namespace UnitTests
{
    public class TirePressureMonitoringSystemTests
    {
        private Mock<ISensor> sensor;
        private Mock<IAlarm> alarm;

        [SetUp]
        public void Initialization()
        {
            this.sensor = new Mock<ISensor>();
            this.alarm = new Mock<IAlarm>();
        }

        [Test]
        public void TirePressureIsFine()
        {
            sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(20D);
            Assert.That(alarm.CallBase.Equals(false));
        }
    }
}
