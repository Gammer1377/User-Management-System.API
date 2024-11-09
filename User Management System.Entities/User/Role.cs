using User_Management_System.Entities.Common;

namespace User_Management_System.Entities.User;

public class Role : BaseEntity
{
    public string Name { get; set; }

    #region Relations

    public ICollection<UserRole> UserRoles { get; set; }

    #endregion
}