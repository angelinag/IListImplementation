using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class ListImplementation : IList<int>
    {
        private int[] array;

        public int this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch
                {
                    return -1;
                }
            }
            set
            {
                array[index] = value; // todo: fix array index overload
            }
        }

        public int Count
        {
            get
            {
                return this.array != null ? this.array.Length : 0;
            }
        }

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
            //Array.Copy(this.array, 0, array, arrayIndex, this.array.Length);
            for (int i = 0; i < this.array.Length; i++)
            {
                array[arrayIndex + i] = this.array[i]; // Array.copy ?????????????
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new ListImplementationEnum(array) as IEnumerator<int>;
        }

        public int IndexOf(int item)
        {
            if (!this.Contains(item))
                throw new Exception();
            return Array.IndexOf(array, item);
        }

        public void Insert(int index, int item)
        {
            int newCount = Count + 1;
            int[] arr = new int[newCount];
            for (int i = 0; i < index - 1; i++)
            {
                arr[i] = array[i];
            };
            arr[index] = item;
            int nextIndex = index + 1;
            for (int j = nextIndex; j <= newCount; j++)
            {
                arr[nextIndex] = array[nextIndex - 1];
            } // todo -1. implement with copy 2. handle arrayexception as listexception

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
            int newCount = Count - 1;
            int[] arr = new int[newCount];
            Array.Copy(array, 0, arr, 0, index);
            Array.Copy(array, index + 1, arr, index, newCount - index);
            array = arr;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
