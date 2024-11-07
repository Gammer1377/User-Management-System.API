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
    public class RoleFluentConfigs:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(30);
            builder.Property(b => b.Id).ValueGeneratedNever();
            builder.HasData(new Role {Id = 1,Name = "مدیریت",CreateDate = DateTime.Now,LastUpdateDate = DateTime.Now}
                , new Role { Id = 2, Name = "کاربر", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now });
        }
    }
}
