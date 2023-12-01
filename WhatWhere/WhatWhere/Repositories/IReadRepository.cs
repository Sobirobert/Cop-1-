using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll(string url);

        T GetByIdAGD(int id);

        T GetByIdGroceries(int id);

        T GetByIdKitchenAccessories(int id);

        void WriteAllConsoleFromFileAGD(IRepository<AGD> repository1);

        void WriteAllConsoleFromFileGroceries(IRepository<Groceries> repository1);

        void ReadAllConsoleFromFileKitchenAccessories(IRepository<KitchenAccessories> repository1);

        void ClearAllFile();

        // object GetAll();
    }
}