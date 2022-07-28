using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class MyArrayListHelper : IList
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.33;
        private int _count;
        private int[] _array;

        public int Capacity => _array.Length;
        public int Length => _count;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                AddByIndex(index, value);
            }
            
        }

        public MyArrayListHelper() : this(DefaultSize)
        {
        }

        public MyArrayListHelper(int size)
        {
            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
        }

        public MyArrayListHelper(int[] array)
        {
            if(array == null)
            {
                throw new ArgumentException();
            }

            int size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }

        public int[] ToArray()
        {
            int[] result = new int[Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }
 
        public void AddBack(int itemToAdd)
        {
            AddByIndex(Length, itemToAdd);
        }

        public void AddBack(IEnumerable<int> items)
        {
            foreach(int item in items)
            {
                AddBack(item);
            }
        }

        public void AddByIndex(int index, int itemToAdd)
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentException();
            }

            if(Capacity == Length)
            {
                int[] newArray = new int[(int)(_array.Length * Coef)];
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }

            int[] arrayAddByIndex = new int[_array.Length];
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

        public void AddByIndex(int index, IEnumerable<int> items)
        {
            foreach (int item in items)
            {
                AddByIndex(index, item);
                index++;
            }
        }

        public void AddFront(int itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddFront(IEnumerable<int> items)
        {
            int start = 0;
            foreach (var item in items)
            {
                AddByIndex(start, item);
                start++;
            }
        }

        public int IndexOf(int element)
        {
            int result = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if(_array[i] == element)
                {
                    result = i;
                    return result;
                }
            }

            return result;
        }

        public int Max()
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
                if(_array[i] > _array[MaxI])
                {
                    MaxI = i;
                }
            }

            return MaxI;
        }

        public int Min()
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
                if (_array[i] < _array[MinI])
                {
                    MinI = i;
                }
            }

            return MinI;
        }

        public int RemoveBack()
        {
            return RemoveByIndex(Length - 1);
        }

        public int RemoveByIndex(int index)
        {
            if (index > Length || index < 0 || Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int result = _array[index];

            int[] newArray = new int[_array.Length];
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

        public int RemoveByValue(int value)
        {
            int index = IndexOf(value);

            if (index == -1)
            {
                return index;
            }

            RemoveByIndex(index);

            return index;
        }

        public int RemoveByValueAll(int value)
        {
            int num = 0;
            for (int i = 0; i < Length; i++)
            {
                if(value == _array[i])
                {
                    RemoveByValue(value);
                    i--;
                    num++;
                }
            }

            return num;
        }

        public int RemoveFront()
        {
            return RemoveByIndex(0);
        }

        public int[] RemoveNValuesBack(int n)
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

        public int[] RemoveNValuesByIndex(int index, int n)
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

        public int[] RemoveNValuesFront(int n)
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

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
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
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (ascending == false && _array[i] < _array[j])
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                    else if(ascending == true && _array[i] > _array[j])
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }
    }
}
