using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace SkeletonTests
{
    public class HeroTests
    {
        private const string HeroName = "Pesho";
        //Fake Weapon and Target
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            ITarget fakeTarget = new FakeTarget();
            IWeapon fakeWeapon = new FakeWeapon();

            Hero hero = new Hero(HeroName, fakeWeapon);
            hero.Attack(fakeTarget);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

        //Mocking
        [Test]
        public void Mocking_HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<ITarget> fakeTarget=new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p=>p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon=new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }

   
}
