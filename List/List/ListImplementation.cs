using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class ListImplementation : IList<int>
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
                    return 0; // todo
                }
            }
            set
            {
                array[index] = value;
            }
        }

        public int Count
        {
            get
            {
                try
                {
                    return this.array.Length;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public bool IsReadOnly => false; //todo

        public void Add(int item)
        {
            if (Count == 0)
            {
                int[] arr = new int[1] { item };
                array = new int[1];
                array = arr;
            }
            else
            {
                int newCount = Count + 1;
                int[] arr = new int[newCount];
                for(int i=0; i<Count; i++)
                {
                    arr[i] = array[i];
                }
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
            for (int i = 0; i < this.array.Length; i++)
            {
                int n = arrayIndex + i;
                array[n-1] = this.array[i];
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new ListImplementationEnum(array) as IEnumerator<int>;
        }

        public int IndexOf(int item)
        {
            if (!this.Contains(item)) throw new Exception();
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
            }

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
            for (int i = 0; i < index; i++)
            {
                arr[i] = array[i];
            };
            for (int j = index; j < newCount; j++)
            {
                arr[j] = array[j + 1];
            };

            array = arr;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
