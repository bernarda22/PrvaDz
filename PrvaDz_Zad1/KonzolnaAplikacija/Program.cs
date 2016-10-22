using System;

namespace KonzolnaAplikacija
{
    class program
    {
        static void Main(string[] args)
        {
            string sizeInput = Console.ReadLine();
            int size = Convert.ToInt32(sizeInput);
            IIntegerList list = new IntegerList(size);

            new program().ListExample(list);
        }

        public void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add(2); // [1,2] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add(3); // [1,2,3] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add(4); // [1,2,3,4]
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add(5); // [1,2,3,4,5]
            Console.WriteLine(listOfIntegers);
            listOfIntegers.RemoveAt(0); // [2,3,4,5] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Remove(5);
            Console.WriteLine(listOfIntegers);
            Console.WriteLine(listOfIntegers.Count); // 3 
            Console.WriteLine(listOfIntegers.Remove(100)); // false 
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false 
            listOfIntegers.Clear(); // [] 
            Console.WriteLine(listOfIntegers.Count); // 0
            Console.ReadLine();
        }

    }

    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);
        /// <summary >
        /// /// Readonly property . Gets the number of items contained in the collection.
        /// </ summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(int item);
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
   
        private int _length = 0;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        override public string ToString() {
            return string.Join(",", _internalStorage);
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange_NeedNonNegNum");
            }

           _internalStorage = new int[initialSize];
        }

        public void Add(int item)
        {
            if (_length >= _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }

            _internalStorage[_length] = item;
            _length++;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _length)
            {
                return false;
            }
            else
            {
                for (int i = index; i < _internalStorage.Length - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                --_length;
    
                return true;
            }
        }

        public bool Remove(int item)
        {
            int pozicija = IndexOf(item);
            if (pozicija == -1)
            {
                return false;
            }
            return RemoveAt(pozicija);
        }


        public int GetElement(int index)
        {
            if (index >= _length)
            {
                throw new IndexOutOfRangeException("Index out of a range");  
            }
            
            return _internalStorage[index];
        }

        public int Count
        {
            get
            {
                return _length;
            }
        }

        public void Clear()
        {
            _internalStorage = new int[_internalStorage.Length];
            _length = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_internalStorage[i] == item)
                    return true;
            }
            return false;
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
