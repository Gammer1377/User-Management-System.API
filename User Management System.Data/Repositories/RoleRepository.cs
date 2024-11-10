using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.User;

namespace User_Management_System.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
