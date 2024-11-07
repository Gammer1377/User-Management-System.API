using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;

namespace User_Management_System.Data.Repositories
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region NormalMethods
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        //public TEntity GetByID(int id)
        //{
         
        //}
        #endregion

        #region AsyncMethods

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        #endregion





    }
}
