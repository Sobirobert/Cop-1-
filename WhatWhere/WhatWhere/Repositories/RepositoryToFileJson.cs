using System.Text.Json;
using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    internal class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly List<T> _items = new();
        protected static readonly string fileName = "FileWrite";
        protected readonly string uRLFile = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\{fileName}.json";
       
        public delegate void ItemAdded(object item);

        private readonly ItemAdded _itemAddedCallback;

        private readonly Action<T> itemAddedCallback;
        private readonly Action<T> itemRemovedCallback;

        //public event EventHandler<T>? ItemAdded;
        //public event EventHandler<T>? ItemRemoved;
        public void Add(T itemToSave)
        {
            var json = JsonSerializer.Serialize<T>(itemToSave);
            File.WriteAllText(uRLFile, json);
            Console.WriteLine("Conversion to file Json successful.");
            itemToSave.Id = _items.Count + 1;
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

        }

        public static void WriteAllConsole(IReadRepository<IEntity> repository)
        {
            //string jsonString = File.ReadAllText($"D:/Programowanie2/Cop 1/Cop-1-/WhatWhere/WhatWhere/bin/Debug/net7.0");
            //T repositoryToRead = JsonConvert.DeserializeObject<repository>(jsonString);
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        //public static void ReadFiles()
        //{
        //    var document1 = File.ReadAllText(nameFile);
        //    var document2 = File.ReadAllLines(nameFile);
        //}
        //public static void GenerateDocuments()
        //{
        //    Console.WriteLine("Insert name");
        //    File.WriteAllText($"D:/Programowanie2/Cop_1/Cop-1-/WhatWhere", fileName);

        //}

    }
}

