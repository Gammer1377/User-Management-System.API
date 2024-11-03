using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace User_Management_System.Data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
     
    }
}
