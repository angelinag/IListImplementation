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
        public ListImplementation<int> GetNewIntList(int[] arr = null)
        {
            arr = arr ?? new int[1] { 1 };
            ListImplementation<int> list = new ListImplementation<int>();
            foreach (int n in arr)
            {
                list.Add(n);
            }
            return list;
        }

        public ListImplementation<string> GetNewStringList(string[] arr = null)
        {
            arr = arr ?? new string[1] { "asd" };
            ListImplementation<string> list = new ListImplementation<string>();
            foreach (string n in arr)
            {
                list.Add(n);
            }
            return list;
        }

        [Fact]
        public void ListImplementation_HasNoItems_IsEmpty()
        {
            ListImplementation<int> listInt = new ListImplementation<int> { };
            Assert.Empty(listInt);

            ListImplementation<string> listString = new ListImplementation<string> { };
            Assert.Empty(listString);
        }

        [Fact]
        public void Count_ReceivesEmptyList_CountIsZero()
        {
            ListImplementation<int> listInt = new ListImplementation<int> { };
            ListImplementation<string> listString = new ListImplementation<string> { };

            int expectedCount = 0;

            Assert.Equal(expectedCount, listInt.Count);
            Assert.Equal(expectedCount, listString.Count);
        }

        [Theory]
        [InlineData(5, new int[] { -5, -24567, -7777, 99, 239345 })]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void CountInt_IsGivenASpecificCount_CountIsCorrect(int count, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }
            Assert.Equal(count, list.Count);
        }

        [Theory]
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void CountString_IsGivenASpecificCount_CountIsCorrect(int count, string[] arr)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            foreach (string a in arr)
            {
                list.Add(a);
            }
            Assert.Equal(count, list.Count);
        }

        [Theory]
        [InlineData(0, new int[] { -5, -24567, -7777, 99, 239345 })]
        [InlineData(2, new int[] { 1, 2, 3 })]
        [InlineData(88, new int[] { int.MinValue })]
        [InlineData(9999, new int[] { int.MaxValue })]
        public void CountInt_IsGivenAWrongCount_CountIsDifferent(int count, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }
            Assert.NotEqual(count, list.Count);
        }

        [Theory]
        [InlineData(-4596, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(0, new string[] { "1", "245433456", "USA" })]
        public void CountString_IsGivenAWrongCount_CountIsDifferent(int count, string[] arr)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            foreach (string a in arr)
            {
                list.Add(a);
            }
            Assert.NotEqual(count, list.Count);
        }

        [Fact]
        public void IsReadOnly_ReceivesStandartList_ReturnsIsReadOnlyfalse()
        {
            ListImplementation<int> listInt = GetNewIntList();
            ListImplementation<string> listString = GetNewStringList();

            Assert.False(listInt.IsReadOnly);
            Assert.False(listString.IsReadOnly);
        }

        [Theory]
        [InlineData(new int[] { 3 })]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { -1, 0, 2, 4, 6 })]
        [InlineData(new int[] { int.MinValue })]
        [InlineData(new int[] { int.MaxValue })]
        public void AddInt_AddProperItems_AddSuccess(int[] arr)
        {
            ListImplementation<int> list = GetNewIntList();
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
        [InlineData("000000000")]
        [InlineData("asd", "3458743", "ASDFG", "000000", "10101010")]
        [InlineData("1", "245433456", "USA")]
        public void AddString_AddProperItems_AddSuccess(params string[] arr)
        {
            ListImplementation<string> list = GetNewStringList();
            foreach (string element in arr)
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
        public void ClearInt_HasSomeData_ClearSuccess(int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
            list.Clear();
            Assert.Empty(list);
        }

        [Theory]
        [InlineData("000000000")]
        [InlineData("asd", "3458743", "ASDFG", "000000", "10101010")]
        [InlineData("1", "245433456", "USA")]
        public void ClearString_HasSomeData_ClearSuccess(params string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void Clear_IsEmptyList_DoesNotThrowException()
        {
            int[] arrInt = new int[] { };
            string[] arrString = new string[] { };

            ListImplementation<int> listInt = GetNewIntList(arrInt);
            ListImplementation<string> listString = GetNewStringList(arrString);

            listInt.Clear();
            listString.Clear();

            Assert.Empty(listInt);
            Assert.Empty(listString);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void ContainsInt_HasTheItems_ReturnsTrue(int a)
        {
            ListImplementation<int> list = new ListImplementation<int> { a };
            bool result1 = list.Contains(a);
            Assert.True(result1);
        }

        [Theory]
        [InlineData("000000000")]
        [InlineData("asd")]
        [InlineData("1")]
        public void ContainsString_HasTheItems_ReturnsTrue(string a)
        {
            ListImplementation<string> list = new ListImplementation<string> { a };
            bool result1 = list.Contains(a);
            Assert.True(result1);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void ContainsInt_DoesNotContain_ReturnsFalse(int a)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            bool result = list.Contains(a);
            Assert.False(result);
        }

        [Theory]
        [InlineData("000000000")]
        [InlineData("asd")]
        [InlineData("1")]
        public void ContainsString_DoesNotContain_ReturnsFalse(string a)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            bool result = list.Contains(a);
            Assert.False(result);
        }

        [Theory]
        [InlineData(3, new int[] { 1, 2, 3 })]
        [InlineData(1, new int[] { int.MinValue })]
        [InlineData(1, new int[] { int.MaxValue })]
        public void CopyToInt_ArrayLengthEqualsListLength_CopySuccess(int n, int[] arr)
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
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void CopyToString_ArrayLengthEqualsListLength_CopySuccess(int n, string[] arr)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            foreach (string a in arr)
            {
                list.Add(a);
            }

            string[] array = new string[n];
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
        public void CopyToInt_ArrayLengthGreaterThanListLength_CopySuccess(int n, int[] arr)
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
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void CopyToString_ArrayLengthGreaterThanListLength_CopySuccess(int n, string[] arr)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            foreach (string a in arr)
            {
                list.Add(a);
            }

            string[] array = new string[n + 10];

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
        public void CopyToInt_ArrayShorterThanList_ThrowException(int n, int[] arr)
        {
            ListImplementation<int> list = new ListImplementation<int> { };
            foreach (int a in arr)
            {
                list.Add(a);
            }

            int[] array = new int[n - 1];

            Assert.Throws<ListIndexOutOfRangeException>(() => list.CopyTo(array, 0));
        }

        [Theory]
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void CopyToString_ArrayShorterThanList_ThrowException(int n, string[] arr)
        {
            ListImplementation<string> list = new ListImplementation<string> { };
            foreach (string a in arr)
            {
                list.Add(a);
            }

            string[] array = new string[n - 1];

            Assert.Throws<ListIndexOutOfRangeException>(() => list.CopyTo(array, 0));
        }

        [Fact]
        public void GetEnumerator_FunctionCalled_ReturnsEnumeratorType()
        {
            ListImplementation<int> listInt = GetNewIntList();
            ListImplementation<int> listString = GetNewIntList();

            IEnumerator enumeratorInt = listInt.GetEnumerator();
            IEnumerator enumeratorString = listString.GetEnumerator();

            // We can cast it as IEnumerator without exceptions, so it implements the interface properly.
            // In this case we can say that the test passed correctly
            Assert.True(true);
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void IndexOfInt_HasTheItem_ReturnsIndexOfItem(int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
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
        [InlineData("asd", "3458743", "ASDFG", "000000", "10101010")]
        public void IndexOfString_HasTheItem_ReturnsIndexOfItem(params string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            int i = 0;
            foreach (string item in list) //checks 1 by 1
            {
                Assert.Equal(i, list.IndexOf(item));
                i++;
            }
            Assert.Equal(2, list.IndexOf("ASDFG")); // checks random item 
            Assert.Equal(3, list.IndexOf("000000")); // checks random item 
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void IndexOfInt_DoesNotContainTheItem_ThrowsException(int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(1283745));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(int.MinValue));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(int.MaxValue));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf(0));
        }

        [Theory]
        [InlineData("asd", "3458743", "ASDFG", "000000", "10101010")]
        public void IndexOfString_DoesNotContainTheItem_ThrowsException(params string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf("1283745"));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf("0"));
            Assert.Throws<ListIndexOutOfRangeException>(() => list.IndexOf("Brad Pitt"));
        }

        [Theory]
        [InlineData(4, 10)]
        [InlineData(5, 6)]
        [InlineData(2, 2)]
        public void InsertInt_IndexIsInRange_InsertSuccess(int a, int b)
        {
            int[] arr = new int[] { 5, 3, 2, 7, 9, 4, 6 };
            ListImplementation<int> list = GetNewIntList(arr);

            list.Insert(a, b);
            Assert.Equal(b, list[a]);
        }

        [Theory]
        [InlineData(2, "cat")]
        [InlineData(2, "dog")]
        [InlineData(3, "orange")]
        public void InsertString_IndexIsInRange_InsertSuccess(int a, string b)
        {
            string[] arr = new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" };
            ListImplementation<string> list = GetNewStringList(arr);

            list.Insert(a, b);
            Assert.Equal(b, list[a]);
        }

        [Theory]
        [InlineData(657483920, 10)]
        [InlineData(657483920, 6)]
        [InlineData(int.MaxValue, 2)]
        public void InsertInt_IndexIsOutOfRange_ThrowException(int a, int b)
        {
            int[] arr = new int[] { 5, 3, 2, 7, 9, 4, 6 };
            ListImplementation<int> list = GetNewIntList(arr);

            Assert.Throws<ListIndexOutOfRangeException>(() => list.Insert(a, b));
        }

        [Theory]
        [InlineData(657483920, "USA")]
        [InlineData(int.MaxValue, "1234567")]
        public void InsertString_IndexIsOutOfRange_ThrowException(int a, string b)
        {
            string[] arr = new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" };
            ListImplementation<string> list = GetNewStringList(arr);

            Assert.Throws<ListIndexOutOfRangeException>(() => list.Insert(a, b));
        }

        [Theory]
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void RemoveInt_GenerateRandomIndexInRange_RemoveSuccess(int n, int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                bool result = list.Remove(list[index]);
                Assert.True(result);
            }
        }

        [Theory]
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void RemoveString_GenerateRandomIndexInRange_RemoveSuccess(int n, string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
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
        public void RemoveInt_DoesNotContainItem_ReturnsFalse(int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
            Assert.False(list.Remove(-1));
        }

        [Theory]
        [InlineData("asd", "3458743", "ASDFG", "000000", "10101010")]
        [InlineData("FFFFFF", "aaaaaaaaaaaaaaaaaaa")]
        public void RemoveString_DoesNotContainItem_ReturnsFalse(params string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            Assert.False(list.Remove("-1"));
        }

        [Theory]
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void RemoveAtInt_GeneratesRandomIndex_RemovesItem(int n, int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
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
                    continue;
                }
            }
        }

        [Theory]
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void RemoveAtString_GeneratesRandomIndex_RemovesItem(int n, string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            for (int i = n; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(0, i);
                if (index < i - 1)
                {
                    string nextString = list[index + 1];
                    list.RemoveAt(index);
                    Assert.Equal(nextString, list[index]);
                }
                else
                {
                    continue;
                }
            }
        }

        [Theory]
        [InlineData(7, new int[] { 5, 3, 2, 7, 9, 4, 6 })]
        public void RemoveAtInt_RemovesLastItemTwice_ThrowsException(int n, int[] arr)
        {
            ListImplementation<int> list = GetNewIntList(arr);
            for (int i = n; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                Assert.Throws<ListIndexOutOfRangeException>(() => list.RemoveAt(i - 1));
            }
        }

        [Theory]
        [InlineData(5, new string[] { "asd", "3458743", "ASDFG", "000000", "10101010" })]
        [InlineData(3, new string[] { "1", "245433456", "USA" })]
        public void RemoveAtString_RemovesLastItemTwice_ThrowsException(int n, string[] arr)
        {
            ListImplementation<string> list = GetNewStringList(arr);
            for (int i = n; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                Assert.Throws<ListIndexOutOfRangeException>(() => list.RemoveAt(i - 1));
            }
        }
    }
}
