using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Management_System.Entities.User;

namespace User_Management_System.Data.FluentConfigs
{
    class UserRoleFluentConfigs : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(UR => new { UR.RoleID, UR.UserID });
            builder.HasOne(b => b.User).WithMany(b => b.UserRoles).HasForeignKey(b => b.UserID);
            builder.HasOne(b => b.Role).WithMany(b => b.UserRoles).HasForeignKey(b => b.RoleID);
            builder.HasData(new UserRole {UserID = 1,RoleID = 1}, new UserRole { UserID = 2,RoleID = 2});
        }
    }
}
