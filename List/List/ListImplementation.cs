using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ListImplementation : IList<int>
    {
        private int[] array;

        public ListImplementation()
        {
            this.array = new int[0] { };
        }

        public int this[int index]
        {
            get
            {
                return (array == null) || (index < 0) || (index >= this.array.Length) ? -1 : array[index];
            }
            set
            {
                if (index >= array.Length) throw new ListIndexOutOfRangeException("The selected index is out of the list range");
                array[index] = value;
            }
        }

        public int Count => this.array != null ? this.array.Length : 0;

        public bool IsReadOnly => false;

        public void Add(int item)
        {
            if (Count == 0)
            {
                array = new int[1] { item };
            }
            else
            {
                int[] arr = new int[Count + 1];

                Array.Copy(array, 0, arr, 0, Count);
                arr[Count] = item;

                array = arr;
            }
        }

        public void Clear()
        {
            array = new int[] { };
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == item) return true;
            }
            return false;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            if ((array.Length - arrayIndex < this.array.Length) || (arrayIndex < 0))
                throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            Array.Copy(this.array, 0, array, arrayIndex, this.array.Length);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new ListImplementationEnum(array) as IEnumerator<int>;
        }

        public int IndexOf(int item)
        {
            if (!this.Contains(item))
                throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            return Array.IndexOf(array, item);
        }

        public void Insert(int index, int item)
        {
            int newCount = Count + 1;
            int[] arr = new int[newCount];

            if ((index > this.array.Length) || (index < 0)) throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            Array.Copy(this.array, 0, arr, 0, index);

            arr[index] = item;
            int nextIndex = index + 1;

            Array.Copy(this.array, index, arr, nextIndex, newCount - index - 1);

            array = arr;
        }

        public bool Remove(int item)
        {
            if (!this.Contains(item)) return false;

            int index = Array.IndexOf(array, item);

            this.RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            int newCount = this.Count - 1;

            if ((index >= Count) || (index < 0)) // if index=count=0 (empty array) or if index is negative
            {
                throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            }
            else if (index == Count - 1) // if element to be removed is last element in the list
            {
                int[] arr = new int[newCount];
                Array.Copy(array, 0, arr, 0, newCount);
                array = arr;
            }
            else // if element to be removed isnt the last element in the list
            {
                int[] arr = new int[newCount];
                Array.Copy(array, 0, arr, 0, index);
                Array.Copy(array, index + 1, arr, index, newCount - index);
                array = arr;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
