using User_Management_System.Entities.Common;

namespace User_Management_System.Entities.User;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    #region Relations

    public ICollection<UserRole> UserRoles { get; set; }

    #endregion
}