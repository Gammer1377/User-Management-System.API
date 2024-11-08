using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_System.Data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        #region NormalMethods

        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Delete(object Id);
        void Update(TEntity entity);
        void SaveChanges();

        #endregion

    }
}
