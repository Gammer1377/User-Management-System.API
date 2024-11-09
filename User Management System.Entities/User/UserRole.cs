namespace User_Management_System.Entities.User;

public class UserRole
{
    public int UserID { get; set; }
    public int RoleID { get; set; }

    #region Relations

    public User User { get; set; }
    public Role Role { get; set; }

    #endregion
}