using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using User_Management_System.Entities.DTOs.User;

namespace User_Management_System.Entities.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User.User, CreateUserDTO>().ReverseMap();
        }
    }
}
