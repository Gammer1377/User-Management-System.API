using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;

namespace User_Management_System.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _Context;
        public GenericRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        
    }
}
