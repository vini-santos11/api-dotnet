using System.Collections.Generic;
using WebAPI.Model.Base;

namespace WebAPI.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T entity);
        T Update(T entity);
        void Delete(long id);
        bool Exists(long id);
    }
}