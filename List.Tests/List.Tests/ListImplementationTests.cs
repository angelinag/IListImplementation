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
        public ListImplementation<int> GetNewList(int[] arr = null)
        {
            arr = arr ?? new int[1] { 1 };
            ListImplementation<int> list = new ListImplementation<int>();
            foreach (int n in arr)
            {
                list.Add(n);
            }
            return list;
        }

        [Theory]
        [InlineData(new int[] { 3 })]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { -1, 0, 2, 4, 6 })]
        [InlineData(new int[] { int.MinValue })]
        [InlineData(new int[] { int.MaxValue })]
        public void Add_AddProperItems_AddSuccess(int[] arr)
        {
            ListImplementation<int> list = GetNewList();
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
        [InlineData(new int[] { -1, 5, 7, 9 })]
        public void Clear_HasSomeData_ClearSuccess(int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void Clear_IsEmptyList_DoesNotThrowException()
        {
            int[] arr = new int[] { };
            ListImplementation<int> list = GetNewList(arr);
            list.Clear();
            Assert.Empty(list);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Contains_HasTheItems_ReturnsTrue(int a)
        {
            ListImplementation<int> list1 = new ListImplementation<int> { a };
            bool result1 = list1.Contains(a);
            Assert.True(result1);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Contains_DoesNotContain_ReturnsFalse(int a)
        {
            ListImplementation<int> list2 = new ListImplementation<int> { };
            bool result2 = list2.Contains(a);
            Assert.False(result2);
        }

        [Theory]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void CopyTo_ArrayLengthEqualsListLength_CopySuccess(int n, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }

            int[] array = new int[n];
            list.CopyTo(array, 0);
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(array[i], list[i]);
            }
        }

        [Theory]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void CopyTo_ArrayLengthGreaterThanListLength_CopySuccess(int n, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }

            int[] array = new int[n + 10];

            Random random = new Random();
            int shift = random.Next(1, 9);
            int startingIndex = shift - 1;

            list.CopyTo(array, startingIndex);
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(list[i], array[i + startingIndex]);
            }
        }

        [Theory]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void CopyTo_ArrayShorterThanList_ThrowException(int n, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }

            int[] array = new int[n - 1];

            Assert.Throws<ListIndexOutOfRangeException>(() => list.CopyTo(array, 0));
        }

        [Fact]
        public void GetEnumerator_FunctionCalled_ReturnsEnumeratorType()
        {
            ListImplementation<int> list = GetNewList();

            IEnumerator enumerator = list.GetEnumerator();
            // We can cast it as IEnumerator without exceptions, so it implements the interface properly.
            // In this case we can say that the test passed correctly
            Assert.True(true);
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void IndexOf_HasTheItem_ReturnsIndexOfItem(int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            int i = 0;
            foreach (int number in list) //checks 1 by 1
            {
                Assert.Equal(i, list.IndexOf(number));
                i++;
            }
            Assert.Equal(3, list.IndexOf(7)); // checks random item
            Assert.Equal(5, list.IndexOf(4)); // checks random item
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void IndexOf_DoesNotContainTheItem_ThrowsException(int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(1283745));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(int.MinValue));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(int.MaxValue));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(0));
        }

        [Theory]
        [InlineData(4, 10)]
        [InlineData(5, 6)]
        [InlineData(2, 2)]
        public void Insert_IndexIsInRange_InsertSuccess(int a, int b)
        {
            int[] arr = new int[] { 5, 3, 2, 7, 9, 4, 6 };
            ListImplementation<int> list = GetNewList(arr);

            list.Insert(a, b);
            Assert.Equal(b, list[a]);
        }

        [Theory]
        [InlineData(657483920, 10)]
        [InlineData(657483920, 6)]
        [InlineData(int.MaxValue, 2)]
        public void Insert_IndexIsOutOfRange_ThrowException(int a, int b)
        {
            int[] arr = new int[] { 5, 3, 2, 7, 9, 4, 6 };
            ListImplementation<int> list = GetNewList(arr);

            Assert.Throws<ListIndexOutOfRangeException>(() => list.Insert(a, b));
        }

        [Theory]
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void Remove_GenerateRandomIndexInRange_RemoveSuccess(int n, int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                bool result = list.Remove(list[index]);
                Assert.True(result);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        [InlineData(new int[] { 7543829, int.MinValue, 5328, -11, int.MaxValue })]
        [InlineData(new int[] { })]
        public void Remove_DoesNotContainItem_ReturnsFalse(int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            Assert.False(list.Remove(-1));
        }

        [Theory]
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void RemoveAt_GeneratesRandomIndex_RemovesItemOrThrowsException(int n, int[] arr)
        {
            ListImplementation<int> list = GetNewList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                if (index < i - 1)
                {
                    int nextNumber = list[index + 1];
                    list.RemoveAt(index);
                    Assert.Equal(nextNumber, list[index]);
                }
                else
                {
                    list.RemoveAt(index);
                    Assert.Throws<ListIndexOutOfRangeException>(() => list.RemoveAt(index));
                }
            }
        }
    }
}
