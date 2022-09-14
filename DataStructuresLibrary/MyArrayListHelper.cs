using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresLibrary
{
    public class MyArrayListHelper<T> : IList<T> where T : IComparable<T>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.33;
        private int _count;
        private T[] _array;

        public int Capacity => _array.Length;
        public int Length => _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new ArgumentException();
                }

                return _array[index];
            }
            set
            {
                if(index >= Length || index < 0)
                {
                    throw new ArgumentException();
                }

                _array[index] = value;
            }
            
        }

        public MyArrayListHelper() : this(DefaultSize)
        {
        }

        public MyArrayListHelper(int size)
        {
            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
        }

        public MyArrayListHelper(T[] array)
        {
            if(array == null)
            {
                throw new ArgumentException();
            }

            int size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new T[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }
 
        public void AddBack(T itemToAdd)
        {
            AddByIndex(Length, itemToAdd);
        }

        public void AddBack(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                AddBack(item);
            }
        }

        public void AddByIndex(int index, T itemToAdd)
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentException();
            }

            if(Capacity == Length)
            {
                T[] newArray = new T[(int)(_array.Length * Coef)];
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }

            T[] arrayAddByIndex = new T[_array.Length];
            for (int i = 0; i < index; i++)
            {
                arrayAddByIndex[i] = _array[i];
            }

            arrayAddByIndex[index] = itemToAdd;

            int startPosition = index + 1;
            for (; startPosition < arrayAddByIndex.Length; startPosition++)
            {
                arrayAddByIndex[startPosition] = _array[startPosition - 1];
            }

            _count++;
            _array = arrayAddByIndex;
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                AddByIndex(index, item);
                index++;
            }
        }

        public void AddFront(T itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddFront(IEnumerable<T> items)
        {
            int start = 0;
            foreach (var item in items)
            {
                AddByIndex(start, item);
                start++;
            }
        }

        public int IndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if(_array[i].CompareTo(element) == 0)
                {
                    result = i;
                    return result;
                }
            }

            return result;
        }

        public T Max()
        {
            return _array[MaxIndex()];
        }

        public int MaxIndex()
        {
            if(Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int MaxI = 0;
            for(int i = 0; i < Length; i++)
            {
                if(_array[i].CompareTo(_array[MaxI]) == 1)
                {
                    MaxI = i;
                }
            }

            return MaxI;
        }

        public T Min()
        {
            return _array[MinIndex()];
        }

        public int MinIndex()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int MinI = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].CompareTo(_array[MinI]) == -1)
                {
                    MinI = i;
                }
            }

            return MinI;
        }

        public T RemoveBack()
        {
            return RemoveByIndex(Length - 1);
        }

        public T RemoveByIndex(int index)
        {
            if (index.CompareTo(Length) == 1 || index < 0 || Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T result = _array[index];

            T[] newArray = new T[_array.Length];
            int i = 0;
            int j = 0;

            while(i < Length - 1)
            {
                if(i == index)
                {
                    j++;
                }

                newArray[i] = _array[j];
                i++;
                j++;
            }

            _array = newArray;
            _count--;
            
            return result;
        }

        public int RemoveByValue(T value)
        {
            int index = IndexOf(value);

            if (index == -1)
            {
                return index;
            }

            RemoveByIndex(index);

            return index;
        }

        public int RemoveByValueAll(T value)
        {
            int num = 0;
            for (int i = 0; i < Length; i++)
            {
                if(value.CompareTo(_array[i]) == 0)
                {
                    RemoveByValue(value);
                    i--;
                    num++;
                }
            }

            return num;
        }

        public T RemoveFront()
        {
            return RemoveByIndex(0);
        }

        public T[] RemoveNValuesBack(int n)
        { 
            if(n > Length || n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                RemoveBack();
            }

            return _array;
        }

        public T[] RemoveNValuesByIndex(int index, int n)
        {
            if ((n + index) > Length || n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                RemoveByIndex(index);
            }

            return _array;
        }

        public T[] RemoveNValuesFront(int n)
        {
            if (n > Length || n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                RemoveFront();
            }

            return _array;
        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void Reverse()
        {
            int end = Length - 1;
            for (int i = 0; i < (Length / 2); i++)
            {
                Swap(ref _array[i], ref _array[end]);
                end--;
            }
        }

        public void Sort(bool ascending = true)
        {
            int coef = ascending ? 1 : -1;
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if(_array[i].CompareTo(_array[j]) == coef)
                    { 
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
