using Microsoft.EntityFrameworkCore;
using User_Management_System.Data.FluentConfigs;
using User_Management_System.Entities.User;

namespace User_Management_System.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserFluentConfigs());
        modelBuilder.ApplyConfiguration(new RoleFluentConfigs());
        modelBuilder.ApplyConfiguration(new UserRoleFluentConfigs());
    }

    #region DbSets

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion
}