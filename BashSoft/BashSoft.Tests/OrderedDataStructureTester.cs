using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Tests
{
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [Test]
        public void TestAddAllKeepsSorted()
        {
            string[] namesCollection = new string[]
            {
                "Gosho",
                "Stamat"
            };

            ICollection<string> items = new List<string>()
            {
                "Gosho",
                "Stamat"
            };

            this.names.AddAll(items);

            Assert.That(namesCollection, Is.EqualTo(this.names));
        }

        [Test]
        public void TestAddIncreaseSize()
        {
            this.names.Add("Valio");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            ICollection<string> items = new List<string>()
            {
                "Stamat",
                "Dimitar"
            };

            this.names.AddAll(items);

            Assert.IsTrue(this.names.Size == 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            ICollection<string> items = new List<string>()
            {
                "Dancho",
                null
            };

            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(items));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("Pesho");
            }

            Assert.IsTrue(this.names.Size == 17);
            Assert.IsTrue(this.names.Capacity != 16);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            string[] namesCollection = new string[] { "Georgi", "Pesho", "Stamat" };

            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Georgi",
                "Pesho",
                "Stamat"
            };

            Assert.That(namesCollection, Is.EqualTo(this.names));
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();

            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [SetUp]
        public void TestInitialize()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Stamat");
            this.names.Add("Mitko");

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Gosho");
            this.names.Add("Pesho");

            Assert.AreEqual("Gosho, Pesho", this.names.JoinWith(", "));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Gosho");

            this.names.Remove("Gosho");

            Assert.IsTrue(this.names.Size == 0);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Gosho");
            this.names.Add("Pesho");

            this.names.Remove("Gosho");

            Assert.IsTrue(this.names.All(x => x != "Gosho"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            this.names.Add("Gosho");

            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }
    }
}