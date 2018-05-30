using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using _02.ExtendedDatabase;

namespace UnitTests
{
    class ExtendedDatabaseTests : DatabaseTests
    {
        [TestFixture]
        public class DatabaseTests
        {
            private Database db;
            private Person personFirst;
            private Person personSecond;

            [SetUp]
            public void Initialization()
            {
                this.db=new Database();
                this.personFirst=new Person(1,"First");
                this.personSecond = new Person(2, "Second");
            }

            [Test]
            public void PersonConstructorTest()
            {
                // Arrange
                Person person = new Person(1337, "TestString");

                // Assert
                Assert.AreEqual(1337, person.Id);
                Assert.AreEqual("TestString", person.UserName);
            }

            [Test]
            public void PersonPropertiesHavePublicSetters()
            {
                // Arrange
                Type personType = typeof(Person);
                PropertyInfo[] propertiesWithPublicSetters = personType
                    .GetProperties()
                    .Where(p => p.SetMethod.IsPublic)
                    .ToArray();

                // Assert
                Assert.AreEqual(0, propertiesWithPublicSetters.Length);
            }

            [Test]
            public void DatabaseInitializationConstructorWithCollectionOfPeople()
            {
                // Arrange               
                List<Person> peopleList = new List<Person>() { this.personFirst, this.personSecond };

                // Act
                this.db = new Database(peopleList);

                // Assert
                Assert.AreEqual(2, this.db.Count, $"Constructor doesn't work with {typeof(Person)} as parameter");
            }

            [Test]
            public void AddPerson()
            {
                // Arrange
                Person person = new Person(111L, "Test");

                // Act
                this.db.Add(person);

                // Assert
                Assert.AreEqual(1, this.db.Count, $"Add {typeof(Person)} doesn't work");
            }

            [Test]
            [TestCase(1, "Test", 1, "Test")]
            [TestCase(1, "Test", 10, "Test")]
            [TestCase(1, "Test", 1, "Pesho")]
            public void CanNotAddPersonWithAlreadyExistingUsernameOrId(long firstId, string firstUsername, long secondId, string secondUsername)
            {
                // Arrange
                Person firstPerson = new Person(firstId, firstUsername);
                Person secondPerson = new Person(secondId, secondUsername);

                // Act
                this.db.Add(firstPerson);

                // Assert
                Assert.Throws<InvalidOperationException>(() => this.db.Add(secondPerson));
            }

            [Test]
            public void RemovePersonFromDataBase()
            {
                // Arrange
                Person firstPerson = new Person(1L, "First");
                Person secondPerson = new Person(2L, "Second");
                Person thirdPerson = new Person(2, "Second");
                this.db.Add(firstPerson);
                this.db.Add(secondPerson);

                // Act
                this.db.Remove(thirdPerson);
                this.db.Remove(firstPerson);

                // Assert
                Assert.AreEqual(0, this.db.Count, $"Remove {typeof(Person)} doesn't work");
            }

            [Test]
            [TestCase(1, "Pesho", 2, "Gosho", 3, "Stamat", 1)]
            [TestCase(1, "Pesho", 2, "Gosho", 3, "Stamat", 2L)]
            [TestCase(1, "Pesho", 2, "Gosho", 3, "Stamat", 3L)]
            public void FindById(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, long keyId)
            {
                // Arrange
                this.db.Add(new Person(firstId, firstUsername));
                this.db.Add(new Person(secondId, secondUsername));
                this.db.Add(new Person(thirdId, thirdUsername));

                // Act
                Person foundPerson = this.db.Find(keyId);

                // Assert
                Assert.AreEqual(keyId, foundPerson.Id, $"Found {typeof(Person)} by Id is not the desired one");
            }

            [Test]
            [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "1L")]
            [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "2L")]
            [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "3L")]
            public void FindByUsername(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, string keyUsername)
            {
                // Arrange
                this.db.Add(new Person(firstId, firstUsername));
                this.db.Add(new Person(secondId, secondUsername));
                this.db.Add(new Person(thirdId, thirdUsername));

                // Act
                Person foundPerson = this.db.Find(keyUsername);

                // Assert
                Assert.AreEqual(keyUsername, foundPerson.UserName, $"Found {typeof(Person)} by Username is not the desired one");
            }

            [Test]
            public void CannotFindUnexistentId()
            {
                // Arrange 
                this.db.Add(new Person(1, "Test"));

                // Assert
                Assert.Throws<InvalidOperationException>(() => this.db.Find(2));
            }

            [Test]
            public void CannotFindNegativeId()
            {
                // Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => this.db.Find(-1));
            }

            [Test]
            public void CannotFindUnexistentUsername()
            {
                // Arrange 
                this.db.Add(new Person(1, "Test"));

                // Assert
                Assert.Throws<InvalidOperationException>(() => this.db.Find("fakeUsername"));
            }

            [Test]
            public void CannotFindUsername()
            {
                // Arrange 
                this.db.Add(new Person(1, "First"));

                // Assert
                Assert.Throws<ArgumentNullException>(() => this.db.Find(null));
            }
        }
    }
}
