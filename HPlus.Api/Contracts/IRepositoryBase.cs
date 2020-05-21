using System.Collections.Generic;

namespace HPlus.Api.Contracts
{
    public interface IRepositoryBase<T>
    {
        ICollection<T> FindAll();
        T FindById(int id);

        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        void Save();

    }
}
