using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Moq;
using NUnit.Framework;
using _01.Database;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7})]
        [TestCase(new int[] {-10})]
        [TestCase(new int[] { })]
        //TestCase becomes int[] inputNumbers
        public virtual void TestValidConstructor(int[] inputNumbers)
        {
            // int[] inputNumbers=new int[]{1,2,3,4};
            Database db = new Database(inputNumbers);

            //string classname = "_01.Database.Database";
            //Type typeOfDB = Type.GetType(classname);
            //if (typeOfDB == null)
            //{
            //    Assert.Fail($"{classname} not found!");
            //}

            //gets the first field in the Database class that is an int[]
            FieldInfo fieldInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));

            IEnumerable<int> actualValues = ((int[]) fieldInfo.GetValue(db)).Take(inputNumbers.Length);

            Assert.That(actualValues, Is.EquivalentTo(inputNumbers));
        }


        [Test]
        public virtual void TestInvalidConstructor()
        {
            int[] inputNumbers = new int[17];

            //requires a delegate!
            Assert.That(() => new Database(inputNumbers), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(-20)]
        [TestCase(500)]
        [TestCase(0)]
        public virtual void TestAddMethodsValid(int value)
        {
            Database db = new Database();

            db.Add(value);
            //gets the array
            FieldInfo valulesInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));
            //gets the currentIndex
            FieldInfo currentIndexInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));

            int firstValue = ((int[]) valulesInfo.GetValue(db)).First();
            Assert.That(firstValue, Is.EqualTo(value));

            int valuesCount = (int) currentIndexInfo.GetValue(db);
            Assert.That(valuesCount, Is.EqualTo(1));

        }

        [Test]
        public virtual void TestAddMethodInvalid()
        {
            int[] inputNumbers = new int[16];
            Database db = new Database();

            FieldInfo currentIndexInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));

            //sets that currentIndex is 16 (array is full) and adds one more int
            currentIndexInfo.SetValue(db, 16);
            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7})]
        [TestCase(new int[] {-10})]
        public virtual void TestRemoveMethod(int[] inputNumbers)
        {
            Database db = new Database(inputNumbers);

            FieldInfo fieldInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));

            //creates new Databases with the differnt TestCase values
            fieldInfo.SetValue(db, inputNumbers);

            FieldInfo currentIndexInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));

            currentIndexInfo.SetValue(db, inputNumbers.Length);

            db.Remove();

            int[] fieldValues = (int[]) fieldInfo.GetValue(db);
            int[] buffer = new int[fieldValues.Length-(inputNumbers.Length-1)];

            inputNumbers = inputNumbers.Take(inputNumbers.Length - 1).Concat(buffer).ToArray();

            Assert.That(fieldValues, Is.EquivalentTo(inputNumbers));
        }

        [Test]
        public virtual void TestRemoveMethodInvalid()
        {
            Database db = new Database();

            FieldInfo currentIndexInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));

            //db's arrays is empty. We can't remove from an empty array
            currentIndexInfo.SetValue(db, 0);

            Assert.That(()=>db.Remove(), Throws.InvalidOperationException);
        }
    }
}
