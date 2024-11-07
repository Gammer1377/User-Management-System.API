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
    public class UserFluentConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.UserName).HasMaxLength(30).IsRequired();
            builder.Property(b => b.Password).IsRequired();
            builder.HasData(new User { Id = 1,UserName = "MobinEfati",Email = "MobinEffati@gmail.com",Password = "12481632",CreateDate = DateTime.Now,LastUpdateDate = DateTime.Now},
                new User { Id = 2,UserName = "ElhamAzizzade", Email = "ElhamAzizzade@gmail.com", Password = "12481632", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now });
        }
    }
}
