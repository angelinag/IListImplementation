using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ListImplementation<T> : IList<T>
    {
        private T[] array;

        public ListImplementation()
        {
            this.array = new T[0] { };
        }

        public T this[int index]
        {
            get
            {
                if ((array == null) || (index < 0) || (index >= this.array.Length))
                    throw new ListIndexOutOfRangeException("The selected index is out of the list range");
                return array[index];
            }
            set
            {
                if (index >= array.Length) throw new ListIndexOutOfRangeException("The selected index is out of the list range");
                array[index] = value;
            }
        }

        public int Count => this.array != null ? this.array.Length : 0;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (Count == 0)
            {
                array = new T[1] { item };
            }
            else
            {
                T[] arr = new T[Count + 1];

                Array.Copy(array, 0, arr, 0, Count);
                arr[Count] = item;

                array = arr;
            }
        }

        public void Clear()
        {
            array = new T[] { };
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((array.Length - arrayIndex < this.array.Length) || (arrayIndex < 0))
                throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            Array.Copy(this.array, 0, array, arrayIndex, this.array.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListImplementationEnum<T>(array) as IEnumerator<T>;
        }

        public int IndexOf(T item)
        {
            if (!this.Contains(item))
                throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            return Array.IndexOf(array, item);
        }

        public void Insert(int index, T item)
        {
            int newCount = Count + 1;
            T[] arr = new T[newCount];

            if ((index > this.array.Length) || (index < 0)) throw new ListIndexOutOfRangeException("The selected index is out of the list range");
            Array.Copy(this.array, 0, arr, 0, index);

            arr[index] = item;
            int nextIndex = index + 1;

            Array.Copy(this.array, index, arr, nextIndex, newCount - index - 1);

            array = arr;
        }

        public bool Remove(T item)
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
                T[] arr = new T[newCount];
                Array.Copy(array, 0, arr, 0, newCount);
                array = arr;
            }
            else // if element to be removed isnt the last element in the list
            {
                T[] arr = new T[newCount];
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
