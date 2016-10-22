using System;

namespace KonzolnaAplikacija
{
    class program
    {
        static void Main(string[] args)
        {
            string sizeInput = Console.ReadLine();
            int size = Convert.ToInt32(sizeInput);
            IGenericList<string> list = new GenericList<string>(size);

            new program().ListExample(list);
        }

        public void ListExample(IGenericList<string> listOfIntegers)
        {
            listOfIntegers.Add("hej"); // [1] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add("haj"); // [1,2] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add("hoj"); // [1,2,3] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add("da"); // [1,2,3,4]
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Add("ne"); // [1,2,3,4,5]
            Console.WriteLine(listOfIntegers);
            listOfIntegers.RemoveAt(0); // [2,3,4,5] 
            Console.WriteLine(listOfIntegers);
            listOfIntegers.Remove("hoj");
            Console.WriteLine(listOfIntegers);
            Console.WriteLine(listOfIntegers.Count); // 3 
            Console.WriteLine(listOfIntegers.Remove("gdje")); // false 
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false 
            listOfIntegers.Clear(); // [] 
            Console.WriteLine(listOfIntegers.Count); // 0
            Console.ReadLine();
        }
    }

    public interface IGenericList<X>
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(X item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(X item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        X GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(X item);
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
        bool Contains(X item);
    }

    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        private int _length = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        override public string ToString()
        {
            return string.Join(",", _internalStorage);
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange_NeedNonNegNum");
            }

            _internalStorage = new X[initialSize];
        }

        public void Add(X item)
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

        public bool Remove(X item)
        {
            int pozicija = IndexOf(item);
            if (pozicija == -1)
            {
                return false;
            }
            return RemoveAt(pozicija);
        }


        public X GetElement(int index)
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
            _internalStorage = new X[_internalStorage.Length];
            _length = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

