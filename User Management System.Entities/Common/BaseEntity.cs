using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_System.Entities.Common
{

    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
