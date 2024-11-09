using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.User;

namespace User_Management_System.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public User GetUserByEmailAndPassword(string email, string password)
    {
        var Result = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        return Result;
    }
}