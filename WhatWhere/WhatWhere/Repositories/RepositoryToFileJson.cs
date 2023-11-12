using System.Text.Json;
using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    internal class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly List<T> _items = new();
        protected static readonly string fileName = "FileWrite";
        protected static readonly string uRLFile = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\{fileName}.json";
       
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
        public IEnumerable<T> GetAll()
        {
            var readfile = File.ReadAllText(uRLFile);
            var json = JsonSerializer.Deserialize<T>(readfile);
            _items.Add(json);
            return _items.ToList();
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

        public void WriteAllConsoleFromFile(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}

