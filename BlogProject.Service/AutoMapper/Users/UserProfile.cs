using AutoMapper;
using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Dtos.Users;
using BlogProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.AutoMapper.Users
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<UserAddDto, AppUser>().ReverseMap();
            CreateMap<UserUpdateDto, AppUser>().ReverseMap();
        }
    }
}
