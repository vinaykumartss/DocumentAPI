using AutoMapper;
using Document.Approve.ApiRequest.Model.UserRequest;
using Document.Approve.ApiRequest.Model.Role;
using Document.Approve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Document.Approve.ApiRequest.Model.Role.RoleRequest;
using Document.Approve.ApiRequest.Model.Department.DepartmentRequest;
using Document.Approve.ApiRequest.Model.UserResponse;

namespace Document_approve_api.AutoMapperConfig
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<UserRequest, User>();
            CreateMap<RoleRequest, Role>();
            CreateMap<DepartmentRequest, Department>();
            CreateMap<User, UserResponse>();

        }
    }
}
