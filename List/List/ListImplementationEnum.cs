using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class ListImplementationEnum<T> : IEnumerator<T>
    {
        private T[] array;

        int position = -1;

        public ListImplementationEnum(T[] arr)
        {
            array = arr;
        }

        public void Dispose() {
            return;
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        
    }
}
