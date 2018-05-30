using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using _04.BubbleSortTest;

namespace UnitTests
{
    class BubbleSortingTests
    {
        [TestFixture]
        public class BubbleTests
        {
            [Test]
            [TestCase(9, 2, 3, 4, 5, 6, 7, 8, 1)]
            [TestCase(9, 8, 7, 6, 5, 4, 3, 2, 1)]
            public void BubbleCanSortNumbers(params int[] numbersToSort)
            {
                Bubble bubble = new Bubble();
                int[] sortedNumbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

                bubble.Sort(numbersToSort);

                CollectionAssert.AreEqual(sortedNumbers, numbersToSort);
            }
        }
    }
}
