using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Model.Base;

namespace WebAPI.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataset;
        public AbstractRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }
        public T Create(T entity)
        {
            try
            {
                _dataset.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar um novo registro.");
            }
        }

        public T Update(T entity)
        {
            if (!Exists(entity.Id)) return null;

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Não foi possível atualizar este registro");
                }
            }
            return entity;
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Não foi possível deletar este registro.");
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }
    }
}