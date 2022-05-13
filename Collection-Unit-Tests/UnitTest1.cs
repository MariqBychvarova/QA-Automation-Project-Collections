using Collections;
using NUnit.Framework;
using System;

namespace Collection_Unit_Tests
{
    public class Tests
    {
        [Test]
        public void Add()
        {
            Collection<int> collection = new Collection<int>();
            int number = 5;
            collection.Add(number);

            Assert.AreEqual(collection[0], 5);
            Assert.AreEqual(collection.Count, 1);
        }

        [Test]
        public void AddRange()
        {
            Collection<int> collection = new Collection<int>();
            int[] range = new int[] { 1, 2, 3, 4, 5 };
            collection.AddRange(range);
           
            Assert.AreEqual(collection.Count, 5);
        }

        [Test]
        public void AddRangeWithGrow()
        {
            int[] range = new int[17];
            Collection<int> collection = new Collection<int>();
            for (int i = 0; i < 17; i++)
            {
                range[i] = i;
            }

            collection.AddRange(range);

            Assert.AreEqual(collection.Capacity, 32);
            Assert.AreEqual(collection.Count, 17);
        }

        [Test]
        public void AddWithGrow()
        {
            Collection<int> collection = new Collection<int>();

            for (int i = 0; i < 17; i++)
            {
                collection.Add(i);
            }

            Assert.AreEqual(collection.Capacity, 32);
            Assert.AreEqual(collection.Count, 17);
        }

        [Test]
        public void Clear()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            collection.Clear();

            Assert.AreEqual(collection.Count, 0);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[0], 0)]
        [Test]
        public void Constructor(int[] argument, int count)
        {
            Collection<int> collection = new Collection<int>(argument);

            Assert.AreEqual(collection.Count, count);
        }

        [Test]
        public void CountAndCapacity()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3);

            Assert.AreEqual(collection.Count, 3);
            Assert.AreEqual(collection.Capacity, 16);
        }

        [TestCase(0, 4, 5, 1)]
        [TestCase(2, 3, 4, 3)]
        [Test]
        public void ValidExchange(int firstIndex, int secondIndex, int firstElement, int secondElement)
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            collection.Exchange(firstIndex, secondIndex);

            Assert.AreEqual(collection[firstIndex], firstElement);
            Assert.AreEqual(collection[secondIndex], secondElement);
        }

        [Test]
        public void ExchangeInvalidIndexes()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);

            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(-1, 0));
        }

        [Test]
        public void GetByIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int number = collection[0];

            Assert.AreEqual(number, 1);
        }

        [Test]
        public void GetByInvalidIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int number = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => number = collection[7]);
        }

        [TestCase(0, 6, 6)]
        [TestCase(2, 6, 6)]
        [TestCase(4, 6, 6)]
        [Test]
        public void InsertAt(int index, int number, int count)
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            collection.InsertAt(index, number);

            Assert.AreEqual(collection[index], number);
            Assert.AreEqual(collection.Count, count);
        }

        [Test]
        public void InsertAtInvalidIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int index = 10;
            int number = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => collection.InsertAt(index, number));
        }

        [Test]
        public void InsertAtWithGrow()
        {
            Collection<int> collection = new Collection<int>();

            for (int i = 0; i < 16; i++)
            {
                collection.Add(i);
            }

            int index = 0;
            int number = 10;
            collection.InsertAt(index, number);

            Assert.AreEqual(collection[index], number);
            Assert.AreEqual(collection.Capacity, 32);
        }

        [TestCase(0, 1, 4)]
        [TestCase(2, 3, 4)]
        [TestCase(4, 5, 4)]
        [Test]
        public void RemoveAt(int index, int removed, int count)
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int result = collection.RemoveAt(index);

            Assert.AreEqual(result, removed);
            Assert.AreEqual(collection.Count, count);
        }

        [Test]
        public void RemoveAll()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            Collection<int> newCollection = new Collection<int>();
            int index = 0;

            while (collection.Count > 0)
            {
                int removed = collection.RemoveAt(index);
                newCollection.Add(removed);
            }

            Assert.AreEqual(collection.Count, 0);
            Assert.AreEqual(newCollection.Count, 5);
        }

        [Test]
        public void RemoveAtInvalidIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int number = 0;
            int index = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => number = collection.RemoveAt(index));
        }

        [Test]
        public void SetByIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int number = 10;
            collection[0] = number;

            Assert.AreEqual(collection[0], number);
        }

        [Test]
        public void SetByInvalidIndex()
        {
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);
            int number = 10;
            int index = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => collection[index] = number);
        }

        [TestCase(new int[]{1, 2, 3}, "[1, 2, 3]")]
        [TestCase(new int[] { 1}, "[1]")]
        [TestCase(new int[0],"[]")]
        [Test]
        public void ToStringTest(int[] argument, string expected)
        {
            Collection<int> collection = new Collection<int>(argument);
            string actual = collection.ToString();

            Assert.AreEqual(actual,expected);
        }
    }
}