using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Database;
using WebAPI.Model;

namespace WebAPI.Repositories
{
    public class PersonRepository : AbstractRepository<Person>, IPersonRepository
    {
        private MySQLContext _context;
        public PersonRepository(MySQLContext context): base(context)
        {
            _context = context;
        }            
    }
}
