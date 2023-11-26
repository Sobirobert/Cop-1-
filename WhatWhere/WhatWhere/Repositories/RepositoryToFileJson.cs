using System.Text.Json;
using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    public class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly List<T> _items1 = new();
        private readonly List<T> _items2 = new();
        private readonly List<T> _items3 = new();
        protected static readonly string fileName1 = "AGDFileWrite";
        protected static readonly string fileName2 = "GroceriesFileWrite";
        protected static readonly string fileName3 = "KitchenAccessoriesFileWrite";
        protected static readonly string uRLFile1 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName1}.json";
        protected static readonly string uRLFile2 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName2}.json";
        protected static readonly string uRLFile3 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName3}.json";

        public event EventHandler<T> ItemAdded;

        public event EventHandler<T> ItemRemoved;

        public void Add(T itemToSave)
        {
            itemToSave.Id = _items1.Count + 1;
            _items1.Add(itemToSave);
            Save();
            ItemAdded?.Invoke(this, itemToSave);
        }
        public void AddGroceries(T itemToSave)
        {
            itemToSave.Id = _items2.Count + 1;
            _items2.Add(itemToSave);
            SaveGroceries();
            ItemAdded?.Invoke(this, itemToSave);
        }
        public void AddKitchenAccessories(T itemToSave)
        {
            itemToSave.Id = _items3.Count + 1;
            _items3.Add(itemToSave);
            SaveKitchenAccessories();
            ItemAdded?.Invoke(this, itemToSave);
        }

        public T? GetById(int id)
        {
            if (id > 0)
            {
                return _items1.Find(item => item.Id == id);
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
                _items1.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("The product doesn't exist");
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items1);
            File.WriteAllText(uRLFile1, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }

        public void SaveGroceries()
        {
            var json2 = JsonSerializer.Serialize(_items2);
            File.WriteAllText(uRLFile3, json2);
            Console.WriteLine("Conversion to file JSON successful.");
        }

        public void SaveKitchenAccessories()
        {
            var json3 = JsonSerializer.Serialize(_items3);
            File.WriteAllText(uRLFile3, json3);
            Console.WriteLine("Conversion to file JSON successful.");
        }

        public IEnumerable<T> GetAll()
        {
            var readfile = File.ReadAllText(uRLFile1);
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
        }

        public void WriteAllConsoleFromFile(RepositoryToFileJson<AGD> repository1)
        {
            var items = repository1.GetAll();
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

        public void ClearJSONFile(string uRLString)
        {
            File.WriteAllText(uRLString, string.Empty);
        }

        public void ClearFile()
        {
            ClearJSONFile(uRLFile1);
            ClearJSONFile(uRLFile2);
            ClearJSONFile(uRLFile3);
        }

        public void RemoveAGDById(IRepository<KitchenAccessories> repository)
        {
            var readfile = File.ReadAllText(uRLFile1);
            var reafFileDeserialize = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (_items1 != null)
            {
                repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
                var json = JsonSerializer.Serialize(_items1);
                File.WriteAllText(uRLFile1, json);
                Console.WriteLine("Conversion to file JSON successful.");
            }
            else
            {
                throw new Exception("File is empty");
            }
        }

        public void RemoveGroceriesById(IRepository<KitchenAccessories> repository)
        {
            var readfile = File.ReadAllText(uRLFile2);
            var reafFileDeserialize = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (_items2 != null)
            {
                repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
                var json = JsonSerializer.Serialize(_items2);
                File.WriteAllText(uRLFile2, json);
                Console.WriteLine("Conversion to file JSON successful.");
            }
            else
            {
                throw new Exception("File is empty");
            }
        }

        public void RemoveKitchenAccessoriesById(IRepository<KitchenAccessories> repository)
        {
            var readfile = File.ReadAllText(uRLFile3);
            var reafFileDeserialize = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (_items3 != null)
            {
                repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
                var json = JsonSerializer.Serialize(_items3);
                File.WriteAllText(uRLFile2, json);
                Console.WriteLine("Conversion to file JSON successful.");
            }
            else
            {
                throw new Exception("File is empty");
            }
        }
    }
}