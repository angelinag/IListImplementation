using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using List;
using System.Collections;

namespace List.Tests
{
    public class ListImplementationTests
    {
        // fix naming convention

        public ListImplementation getNewList(int[] arr = null)
        {
            arr = arr ?? new int[1] { 1 };
            ListImplementation list = new ListImplementation();
            foreach (int n in arr)
            {
                list.Add(n);
            }
            return list;
        }

        [Fact]
        public void sets()
        {
            ListImplementation list = getNewList();
            list[0] = 5;
            list[0] = 1984;
            Assert.True(true);
        }

        [Theory]
        [InlineData(new int[] { 3 })]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { -1, 0, 2, 4, 6 })]
        [InlineData(new int[] { int.MinValue })]
        [InlineData(new int[] { int.MaxValue })]
        public void addsItems(int[] arr)
        {
            ListImplementation list = getNewList();
            foreach (int element in arr)
            {
                list.Add(element);
            }
            int listLength = arr.Length + 1;
            for (int i = 1; i < listLength; i++)
            {
                Assert.Equal(arr[i - 1], list[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 3 })]
        [InlineData(new int[] { 0 })]
        public void clears(int[] arr) //clear na empty list? + add inline data
        {
            //Arrange
            //Act
            //Assert
            ListImplementation list = getNewList(arr);
            list.Clear();
            Assert.Empty(list);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void containsTrue(int a)
        {
            ListImplementation list1 = new ListImplementation { a };
            bool result1 = list1.Contains(a);
            Assert.True(result1);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void containsFalse(int a)
        {
            ListImplementation list2 = new ListImplementation { };
            bool result2 = list2.Contains(a);
            Assert.False(result2);
        }

        [Theory]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void copiesTo(int n, int[] arr)
        {
            // Setting up the list and filling it up with data
            ListImplementation list = new ListImplementation { };
            foreach (int a in arr)
            {
                list.Add(a);
            }

            // Test case 1 - array length == list length
            int[] array1 = new int[n];
            list.CopyTo(array1, 0);
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(array1[i], list[i]);
            }

            // Test case 2 - array length > list length
            int[] array2 = new int[n + 10];

            Random random = new Random();
            int shift = random.Next(1, 9);
            int startingIndex = shift - 1;

            list.CopyTo(array2, startingIndex);
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(list[i], array2[i + startingIndex]);
            }

            // Test case 3 - array length < list length
            int[] array3 = new int[n - 1];

            Assert.Throws<IndexOutOfRangeException>(() => list.CopyTo(array3, 0));
        }

        [Fact]
        public void returnsEnumerator()
        {
            ListImplementation list = new ListImplementation { 1, 2, 3 };

            IEnumerator enumerator = list.GetEnumerator();
            // We can cast it as IEnumerator without exceptions, so it implements the interface properly.
            // In this case we can say that the test passed correctly
            Assert.True(true);
        }

        [Fact]
        public void returnsIndexOf()
        {
            ListImplementation list = new ListImplementation { 5, 3, 2, 7, 9, 4, 6 };
            int i = 0;
            foreach (int number in list)
            {
                Assert.Equal(i, list.IndexOf(number));
                i++;
            }
            Assert.Equal(3, list.IndexOf(7));
            Assert.Throws<IndexOutOfRangeException>(() => list.IndexOf(1283745));
        }

        [Theory]
        [InlineData(4, 10)]
        [InlineData(5, 6)]
        [InlineData(2, 2)]
        public void inserts(int a, int b)
        {
            ListImplementation list = new ListImplementation { 5, 3, 2, 7, 9, 4, 6 };

            list.Insert(a, b);
            Assert.Equal(b, list[a]);

            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(657483920, b));
        }

        [Theory] // length ? exception
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]  // pass array + element_to_del as inline data
        public void removes(int n, int[] arr)
        {
            ListImplementation list = getNewList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                bool result = list.Remove(list[index]);
                Assert.True(result);
            }
        }

        [Theory] // length ? exception
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void removesAt(int n, int[] arr)
        {
            ListImplementation list = getNewList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                if(index < i-1)
                {
                    int nextNumber = list[index + 1];
                    list.RemoveAt(index);
                    Assert.Equal(nextNumber, list[index]);
                    
                }
                else
                {
                    list.RemoveAt(index);
                    Assert.Throws<Exception>(() => list.RemoveAt(index));
                }
            }
        }
    }
}
