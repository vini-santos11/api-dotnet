using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Database;
using WebAPI.Model;

namespace WebAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private MySQLContext _context;
        public PersonRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Não foi possível criar esta pessoa");
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                } catch (Exception) { throw new Exception("Não foi possível atualizar esta pessoa"); }
            }
                return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                } catch (Exception) { throw new Exception("Nao foi possível deletar esta pessoa"); }
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
