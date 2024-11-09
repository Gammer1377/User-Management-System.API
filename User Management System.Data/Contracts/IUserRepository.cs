using User_Management_System.Entities.User;

namespace User_Management_System.Data.Contracts;

public interface IUserRepository
{
    User GetUserByEmailAndPassword(string email, string password);
}