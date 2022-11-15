using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Student;
using ServiceLayer.DTOs.StudentDetail;
using ServiceLayer.DTOs.UserDetail;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppUser, RegisterDto>().ReverseMap();

            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UpdateUserDto>().ReverseMap();
            CreateMap<AppUser, UserDetailDto>().ReverseMap();
            CreateMap<AppUser, UserIdDto>().ReverseMap();
            CreateMap<AppUser, UpdatePasswordDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentEditDto>().ReverseMap();
            CreateMap<StudentDetail, StudentDetailDto>().ReverseMap();
            CreateMap<StudentDetail, StudentDetailEditDto>().ReverseMap();

        }
    }
}
