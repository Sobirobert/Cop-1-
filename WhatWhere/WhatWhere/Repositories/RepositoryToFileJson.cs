using System.Text.Json;
using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    internal class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly List<T> _items = new();
        private readonly List<T> _items2 = new();
        private readonly List<T> _items3 = new();
        protected static readonly string fileName = "AGDFileWrite";
        protected static readonly string fileName2 = "GroceriesFileWrite";
        protected static readonly string fileName3 = "KitchenAccessoriesFileWrite";
        protected static readonly string uRLFile = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\{fileName}.json";
        protected static readonly string uRLFile2 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\{fileName2}.json";
        protected static readonly string uRLFile3 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\{fileName3}.json";

        public delegate void ItemAdded(object item);

        private readonly ItemAdded _itemAddedCallback;

        private readonly Action<T> itemAddedCallback;
        private readonly Action<T> itemRemovedCallback;

        //public event EventHandler<T>? ItemAdded;
        //public event EventHandler<T>? ItemRemoved;
        public void Add(T itemToSave)
        {
            itemToSave.Id = _items.Count + 1;
            _items.Add(itemToSave);
        }
        public void AddInt(string value)
        {
            if (int.TryParse(value, out int number))
            {
                Console.WriteLine("The conversion success.");
            }
            else
            {
                Console.WriteLine("The conversion wasn't successful.");
            }
        }

        public T? GetById(int id)
        {
            if (id > 0)
            {
                return _items.Find(item => item.Id == id);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(T item)
        {
            if (item != null)
            {
                _items.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("The product doesn't exist");
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(uRLFile, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        public void SaveGroceries()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(uRLFile2, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        public void SaveKitchenAccessories()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(uRLFile3, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        public IEnumerable<T> GetAll()
        {
            var readfile = File.ReadAllText(uRLFile);
            var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);

            if (json != null)
            {
                return json.ToList();
            }
            else
            {
                throw new Exception("File is empty");
            }
        }
        public IEnumerable<T> GetAllGroceries()
        {
            var readfile = File.ReadAllText(uRLFile2);
            var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (json != null)
            {
                return json.ToList();
            }
            else
            {
                throw new Exception("File is empty");
            }
        }
        public IEnumerable<T> GetAllKitchenAccessories()
        {
            var readfile = File.ReadAllText(uRLFile3);
            var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (json != null)
            {
                return json.ToList();
            }
            else
            {
                throw new Exception("File is empty");
            }
        public void WriteAllConsoleFromFile(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void WriteAllConsoleFromFileGroceries(RepositoryToFileJson<Groceries> repository2)
        {
            var items = repository2.GetAllGroceries();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void WriteAllConsoleFromFileKitchenAccessories(RepositoryToFileJson<KitchenAccessories> repository3)
        {
            var items = repository3.GetAllKitchenAccessories();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}

