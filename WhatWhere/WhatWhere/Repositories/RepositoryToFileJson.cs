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

        public event EventHandler<T>? ItemAddedFile;

        public event EventHandler<T>? ItemRemovedFile;

        public event IRepository<T>.GradeAddedDelegate GradeAdded;

        public void Add(T itemToSave)
        {
            itemToSave.Id = _items.Count + 1;
            _items.Add(itemToSave);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
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
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
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
            var json = JsonSerializer.Serialize(_items2);
            File.WriteAllText(uRLFile2, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }

        public void SaveKitchenAccessories()
        {
            var json = JsonSerializer.Serialize(_items3);
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
            ClearJSONFile(uRLFile);
            ClearJSONFile(uRLFile2);
            ClearJSONFile(uRLFile3);
        }

        public void RemoveAGDById(IRepository<KitchenAccessories> repository)
        {
            var readfile = File.ReadAllText(uRLFile);
            var reafFileDeserialize = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
            if (_items != null)
            {
                repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
                var json = JsonSerializer.Serialize(_items);
                File.WriteAllText(uRLFile, json);
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
    }
}