using System;
using NUnit.Framework;

namespace SkeletonTests
{
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }


        [Test]
        public void AxeLosesDurability()
        {
            ////Arrange
            //Axe axe=new Axe(10,10);
            //Dummy dummy = new Dummy(10, 10);

            ////Act
            //axe.Attack(dummy);

            ////Assert
            //Assert.That(axe.DurabilityPoints, Is.EqualTo(9));


            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1),
                "Axe Durability doesn't change after arrack");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            // Axe axe = new Axe(10, 1);
            // Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
