using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary
{
    public class MyLinkedListHelper<T> : IList<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _root;

        public int Length => _count;

        public MyLinkedListHelper()
        {
        }

        public MyLinkedListHelper(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            if(array.Length > 0)
            {
                _root = new Node<T> { Value = array[0] };
            }

            Node<T> temp = _root;

            if (array.Length > 1)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    while (temp.Next != null)
                    {
                        temp = temp.Next;
                    }

                    temp.Next = new Node<T> { Value = array[i] };
                }
            }

            _count = array.Length;
        }

        public T this[int index] 
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new ArgumentException();
                }

                int numerator = 0;
                Node<T> temp = _root;
                while (numerator++ < index)
                {
                    temp = temp.Next;
                }

                return temp.Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new ArgumentException();
                }

                Node<T> temp = _root;
                if (index == 0)
                {
                    temp = new Node<T> { Value = value };
                    _root = temp;
                }
                else
                {
                    int nodeIndex = 1;
                    while (nodeIndex++ < index)
                    {
                        temp = temp.Next;
                    }

                    temp.Next = new Node<T> { Value = value, Next = temp.Next.Next };
                }
            } 
        }

        public void AddBack(T itemToAdd)
        {
            AddByIndex(Length, itemToAdd);
        }

        public void AddBack(IEnumerable<T> items)
        {
            int length = Length;
            AddByIndex(length++, items); 
        }

        public void AddByIndex(int index, T itemToAdd)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentException();
            }

            _count++;
            Node<T> temp = _root;
            if (index == 0)
            {
                temp = new Node<T> { Value = itemToAdd, Next = _root };
                _root = temp;
            }
            else
            {
                int nodeIndex = 0;
                index--;
                while (nodeIndex++ < index)
                {
                    temp = temp.Next;
                }

                temp.Next = new Node<T> { Value = itemToAdd, Next = temp.Next };
            }
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                AddByIndex(index++, item);
                _count++;
            }
        }

        public void AddFront(T itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddFront(IEnumerable<T> items)
        {
            int start = 0;
            AddByIndex(start++, items);
        }

        public int IndexOf(T element)
        {
            Node<T> temp = _root;
            int index = 0;
            int result = -1;
            if (element.CompareTo(temp.Value) == 0)
            {
                result = 0;

                return result;
            }

            while (temp.Next != null)
            {
                temp = temp.Next;
                index++;
                if (element.CompareTo(temp.Value) == 0)
                {
                    result = index;

                    return result;
                }
            }
            
            return result;
        }

        public T Max()
        {
            Node<T> temp = _root;
            T max = temp.Value;

            while (temp.Next != null)
            {
                temp = temp.Next;
                if (max.CompareTo(temp.Value) == -1)
                {
                    max = temp.Value;
                }
            }

            return max;
        }

        public int MaxIndex()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return IndexOf(Max());
        }

        public T Min()
        {
            Node<T> temp = _root;
            T min = temp.Value;

            while (temp.Next != null)
            {
                temp = temp.Next;
                if (min.CompareTo(temp.Value) == 1)
                {
                    min = temp.Value;
                }
            }

            return min;
        }

        public int MinIndex()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return IndexOf(Min());
        }

        public T RemoveBack()
        { 
            return RemoveByIndex(Length - 1);
        }

        public T RemoveByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> temp = _root;
            T result = temp.Value;
            if (index == 0)
            {
                _root = temp.Next;
            }
            else
            {
                int nodeIndex = 0;
                while (temp.Next != null)
                {
                    nodeIndex++;
                    if (nodeIndex == index)
                    {
                        result = temp.Next.Value;
                        temp.Next = temp.Next.Next;
                    }
                    else
                    {
                        temp = temp.Next;
                    }
                }
            }

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
            Node<T> temp = _root;
            int num = 0;
            while(temp != null)
            {
                if (value.CompareTo(temp.Value) == 0)
                {
                    RemoveByValue(value);
                    num++;
                }

                temp = temp.Next;
            }

            return num;
        }

        public T RemoveFront()
        {
            return RemoveByIndex(0);
        }

        public T[] RemoveNValuesBack(int n)
        {
            if (n > Length || n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                RemoveBack();
            }

            Node<T> temp = _root;
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }
            
            return array;
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

            Node<T> temp = _root;
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }

            return array;
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

            Node<T> temp = _root;
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }

            return array;
        }

        public void Reverse()
        {
            int length = Length;
            T[] element = new T[Length];

            for (int i = 0; i < length; i++)
            {
                element[i] = RemoveBack();
            }

            for (int i = 0; i < length; i++)
            {
                AddBack(element[i]);
            }
        }

        public void Sort(bool ascending = true)
        {
            int length = Length;
            T[] array = new T[length];

            if (ascending)
            {
                for (int i = 0; i < length; i++)
                {
                    T min = Min();

                    RemoveByValue(min);
                    array[i] = min;
                }

                for (int i = 0; i < length; i++)
                {
                    AddBack(array[i]);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    T max = Max();

                    RemoveByValue(max);
                    array[i] = max;
                }

                for (int i = 0; i < length; i++)
                {
                    AddBack(array[i]);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = _root;
            while(temp != null)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
